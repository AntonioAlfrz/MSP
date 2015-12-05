using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MSPForm
{
    class Justify
    {
        private readonly char[] vocal = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'ü' };
        private readonly char[] tilde = { 'í', 'ú' };
        private readonly char[] fuerte = { 'a', 'e', 'o' };
        private readonly string[] exceptions = { "bl", "cl", "fl", "gl", "ll", "pl", "tl", "br", "cr", "dr", "fr", "gr", "pr", "tr", "ch", "rr" };
        private readonly string[] dipt = { "ia", "ie", "io", "ua", "ue", "uo", "ai", "au", "ei", "eu", "oi", "iu", "ui" };

        private bool isvocal(char c)
        {
            return vocal.Contains(Char.ToLower(c));
        }
        // Quita acentos y diéresis
        private string QuitarSim(string s)
        {
            string pattern = "á";
            Regex rgx = new Regex(pattern);
            s = rgx.Replace(s, "a");
            pattern = "é";
            rgx = new Regex(pattern);
            s = rgx.Replace(s, "e");
            pattern = "ó";
            rgx = new Regex(pattern);
            s = rgx.Replace(s, "o");
            pattern = "í";
            rgx = new Regex(pattern);
            s = rgx.Replace(s, "i");
            pattern = "[úü]";
            rgx = new Regex(pattern);
            return rgx.Replace(s, "u");
        }
        // Separa una palabra en sílabas, Distingue cualquier caso en español (diptongos, triptongos, hiatos)
        private List<string> separa(string word)
        {
            string buffer = "";
            List<string> ret = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!isvocal(word[i]))
                {
                    if (i < word.Length - 1)
                    {
                        if (isvocal(word[i + 1]))
                        {
                            if (buffer.Length != 0)
                            {
                                ret.Add(buffer);
                            }
                            buffer = word[i].ToString();
                            continue;
                        }
                        else
                        {
                            if (exceptions.Contains(word[i].ToString() + word[i + 1].ToString()))
                            {
                                if (buffer.Length != 0)
                                {
                                    ret.Add(buffer);
                                }
                                buffer = word[i].ToString() + word[i + 1].ToString();
                                i++;
                                continue;
                            }
                            if (i < word.Length - 2)
                            {
                                //c-cv
                                if (isvocal(word[i + 2]))
                                {
                                    ret.Add(buffer + word[i]);
                                    buffer = "";
                                    continue;
                                }
                                else
                                {
                                    //c-cc
                                    if (exceptions.Contains((word[i + 1].ToString() + word[i + 2].ToString())))
                                    {
                                        ret.Add(buffer + word[i]);
                                        buffer = word[i + 1].ToString() + word[i + 2].ToString();
                                        i += 2;
                                        continue;
                                    }
                                    else
                                    {
                                        buffer += word[i].ToString();
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                ret.Add(buffer + word[i] + word[i + 1]);
                                buffer = "";
                                break;
                            }
                        }
                    }
                    else
                    {
                        ret.Add(buffer + word[i]);
                        buffer = "";
                        break;
                    }
                }
                // Vocal
                else
                {
                    if (i < word.Length - 1)
                    {
                        if (isvocal(word[i + 1]))
                        {
                            if ((tilde.Contains(word[i]) && fuerte.Contains(word[i + 1])) || (tilde.Contains(word[i + 1]) && fuerte.Contains(word[i])))
                            {
                                ret.Add(buffer + word[i]);
                                buffer = "";
                                continue;
                            }
                            else if (dipt.Contains((QuitarSim(word[i].ToString() + word[i + 1].ToString()))))
                            {
                                buffer += word[i].ToString() + word[i + 1].ToString();
                                i++;
                                continue;

                            }
                            else
                            {
                                ret.Add(buffer + word[i]);
                                buffer = "";
                                continue;
                            }
                        }
                        else
                        {
                            if (i < word.Length - 2)
                            {
                                if (isvocal(word[i + 2]))
                                {
                                    ret.Add(buffer + word[i]);
                                    buffer = "";
                                    continue;
                                }
                                else
                                {
                                    if (exceptions.Contains((word[i + 1].ToString() + word[i + 2].ToString())))
                                    {
                                        ret.Add(buffer + word[i]);
                                        buffer = "";
                                        continue;
                                    }
                                    else
                                    {
                                        buffer += word[i].ToString();
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                ret.Add(buffer + word[i] + word[i + 1]);
                                buffer = "";
                                break;
                            }
                        }
                    }
                    else
                    {
                        ret.Add(buffer + word[i]);
                        buffer = "";
                        break;
                    }
                }
            }
            //Limpiar Buffer
            if (buffer.Length != 0)
            {
                ret.Add(buffer);
            }
            return ret;
        }
        // Método auxiliar que extrae el siguiente elemento de una lista
        private string Pop(ref List<string> lista)
        {
            if (lista.Count == 0)
            {
                return "";
            }
            string word = lista[0];
            lista.RemoveAt(0);
            return word;
        }
        // Justifica un texto
        public List<string> justifica(string text, int col)
        {
            List<string> ret = new List<string>();
            text = text.Trim();
            text = text.Replace("\n", " ");
            // Lista de palabras
            List<string> words = new List<string>(text.Split(' '));
            // Buffer donde se guarda el string a imprimir
            string temp = "";
            // Siguiente palabra a añadir
            string siguiente = Pop(ref words);
            // Guarda la concatenación del buffer y la siguiente palabra
            string append;
            while (words.Count != 0 || siguiente.Length != 0)
            {
                // Comprueba la longitud del buffer con la siguiente palabra
                append = (temp + " " + siguiente).Trim();
                if (append.Length < col)
                {
                    temp = append;
                }
                else if (append.Length == col)
                {
                    ret.Add(append);
                    temp = "";
                }
                // No cabe la siguiente palabra
                // Se ha decidido no separar las palabras si caben en la siguiente fila
                else
                {
                    if (siguiente.Length < col)
                    {
                        ret.Add(temp.Trim());
                        temp = siguiente;
                    }
                    else if (siguiente.Length == col)
                    {
                        ret.Add(temp.Trim());
                        ret.Add(siguiente);
                        temp = "";
                    }
                    // Separa sílabas. Se ha decidido que el guión cuente como carácter
                    else
                    {
                        List<string> silabas = separa(siguiente);
                        if (silabas[0].Length > col)
                        {
                            // Truncar sílaba
                            ret.Add(silabas[0].Remove(col));
                            siguiente = siguiente.Substring(col);
                            continue;
                        }
                        string add_sil = (temp + " " + silabas[0]).Trim();
                        if (add_sil.Length + 1 > col)
                        {
                            ret.Add(temp.Trim());
                            temp = "";
                            continue;
                        }
                        else
                        {
                            temp = add_sil;
                            int suma = 0;
                            for (int i = 1; i < silabas.Count; i++)
                            {
                                suma += silabas[i].Length;
                                if (suma + temp.Length + 1 > col)
                                {
                                    ret.Add(temp + "-");
                                    siguiente = siguiente.Substring(suma + silabas[0].Length - silabas[i].Length);
                                    break;
                                }
                                temp += silabas[i];
                            }
                            temp = "";
                            continue;
                        }

                    }
                }
                siguiente = Pop(ref words);
            }
            if (temp.Length != 0)
            {
                ret.Add(temp.Trim());
            }
            return ret;
        }
    }
}
