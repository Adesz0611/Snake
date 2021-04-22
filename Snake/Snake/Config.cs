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
        private UInt32 speed; /* Gyorsaság századmásodpercben (ms) */
        private bool dieOnWall; /* Meghaljon-e a kígyó, hogyha nekiütközik a falnak */
        private string scoreFile; /* A scoret tartalmazó file elérési útvonala */
        private int scoreAdd; /* Ennyit adunk hozzá az aktuális scorehoz, ha a kígyó megeszik egy dollárt */
        private UInt32 n; /* Config file hossza sorban */
        private string errorMSG; /* Ideiglenes változó, melynek tartalmát kiolvashatjuk a GetError() függvénnyel */
        private List<string[]> rows = new List<string[]>(); /* Nem tudom kifejezni magam xD */ /* TODO: fixelni a commentet */

        public Config() {
            if (!Load())
                Console.WriteLine("Hiba: " + GetError());
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
                if (sor.Length < 1)
                    continue;
                string[] elements = new string[2] {"",""};
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
                        continue;
                    }

                    elements[which] += sor[j];
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
                    Console.WriteLine("Hiba: " + GetError());
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
                    int tmp_add;
                    if (!int.TryParse(p[1], out tmp_add)) {
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