using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Config
    {
        // TODO: ha lesz idő fixálni, hogy a config fájl elérhetőségi útja tartalmazhasson whitespace karaktereket

        private UInt32 speed = 100; /* Gyorsaság századmásodpercben (ms) */
        private bool dieOnWall = true; /* Meghaljon-e a kígyó, hogyha nekiütközik a falnak */
        private string scoreFile = "score.txt"; /* A scoret tartalmazó file elérési útvonala */
        private UInt64 scoreAdd = 10; /* Ennyit adunk hozzá az aktuális scorehoz, ha a kígyó megeszik egy dollárt */
        private UInt32 n; /* Config file hossza sorban */
        private string errorMSG; /* Ideiglenes változó, melynek tartalmát kiolvashatjuk a GetError() függvénnyel */
        private List<string[]> rows = new List<string[]>(); /* Nem tudom kifejezni magam xD */ /* TODO: fixelni a commentet */

        /* -------- Getter függvények -------- */
        // Azért csinálok getter függvényeket, hogy kívülről ne lehessen a változók értékét változtatni, csak olvasni
        public UInt32 getSpeed() {
            return speed;
        }
        public bool getDieOnWall() {
            return dieOnWall;
        }
        public string getScoreFile() {
            return scoreFile;
        }
        public UInt64 getScoreAdd() {
            return scoreAdd;
        }

        public Config() {
            if (!Load()) {
                Console.WriteLine("Hiba: " + GetError());
                Console.ReadKey(true);
                Environment.Exit(1);
            }
        }

        public bool Load() {
            if (!File.Exists("config.txt")) {
                errorMSG = "A konfigurációs file nem létezik!";
                return false;
            }
            
            n = Convert.ToUInt32(File.ReadAllLines("config.txt").Length);
            FileStream f = new FileStream("config.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);


            for (int i = 0; i < n; i++) {
                string sor = sr.ReadLine();
                if (sor.Length < 1) // Üres sorokat ignoráljuk
                    continue;

                /* 0. index: beállítás neve
                   1. index: érték          */
                string[] elements = new string[2] { "", "" };
                int which = 0;
                bool fromComment = false;
                for (int j = 0; j < sor.Length; j++) {
                    if (isWhiteSpace(sor[j]))
                        continue;
                    if (sor[j] == '#') {
                        fromComment = true;
                        break;
                    }
                    if (sor[j] == ':') {
                        which++;
                        if (which > 1)
                            break;
                        continue;
                    }

                    elements[which] += sor[j];
                }

                if (which > 1) {
                    errorMSG = (i + 1) + ". sor: " + "Érvénytelen elválasztó ':' (Egy sorban csak egy kulcs, érték pár szerepelhet)";
                    return false;
                }

                if (elements[0] == "") {
                    if (fromComment && elements[0] == "" && elements[1] == "")
                        continue;
                    errorMSG = (i + 1) + ". sor: " + "Hiányzó kulcs!";
                    
                    return false;
                }
                if (elements[1] == "") {
                    if (fromComment && elements[0] == "" && elements[1] == "")
                        continue;
                    errorMSG = (i + 1) + ". sor: " + "Hiányzó érték!";
                    return false;
                }
                
                rows.Add(elements);
                if (!set(elements, (i + 1)))
                    return false;
            }

            sr.Close();
            f.Close();

            return true;
        }

        public string GetError() {
            return errorMSG;
        }

        private bool isWhiteSpace(char p) {
            if (p == ' ' || p == '\t')
                return true;
            return false;
        }

        public void Print() {
            Console.WriteLine(n);
            for (int i = 0; i < rows.Count; i++) {
                Console.WriteLine(rows[i][0] + ":" + rows[i][1]);
            }

            Console.WriteLine("\n\n\n");
            Console.WriteLine("A kígyó gyorsasága: " + speed);
            Console.WriteLine("Meghaljon a fallal való ütközésbe: " + dieOnWall);
            Console.WriteLine("Score elérési útvonala: " + scoreFile);
            Console.WriteLine("Ennyit adunk a scorehoz: " + scoreAdd);
        }

        private bool set(string[] p, int p_row) {
            switch (p[0]) {
                case "snake_speed":
                    UInt32 tmp_speed;
                    if (!UInt32.TryParse(p[1], out tmp_speed)) {
                        errorMSG = p_row + ". sor: Érvénytelen paraméter: " + p[1] + ", " + p[0] + " közelében!";
                        return false;
                    }
                    speed = tmp_speed;
                    break;
                case "snake_dieOnWall":
                    bool tmp_die;
                    if (!bool.TryParse(p[1], out tmp_die)) {
                        errorMSG = p_row + ". sor: Érvénytelen paraméter: " + p[1] + ", " + p[0] + " közelében!";
                        return false;
                    }
                    dieOnWall = tmp_die;
                    break;
                case "score_file":
                    scoreFile = p[1];
                    break;
                case "score_add":
                    UInt64 tmp_add;
                    if (!UInt64.TryParse(p[1], out tmp_add)) {
                        errorMSG = p_row + ". sor: Érvénytelen paraméter: " + p[1] + ", " + p[0] + " közelében!";
                        return false;
                    }
                    scoreAdd = tmp_add;
                    break;
                default:
                    errorMSG = p_row + ". sor: Ismeretlen kulcsszó: " + p[0];
                    return false;
            }

            return true;
        }
    }
}