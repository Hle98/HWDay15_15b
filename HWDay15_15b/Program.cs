using System;
using System.Collections.Generic;

namespace HWDay15_15b
{
    class Program
    {
        static void Main(string[] args)
        {
            var elementSymbol = new List<string> { "H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br", "Kr", "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn", "Sb", "Te", "I", "Xe", "Cs", "Ba", "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb", "Lu", "Hf", "Ta", "W", "Re", "Os", "Ir", "Pt", "Au", "Hg", "TI", "Pb", "Bi", "Po", "At", "Rn", "Fr", "Ra", "Ac", "Th", "Pa", "U", "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No", "Lr", "Rf", "Db", "Sg", "Bh", "Hs", "Mt", "Ds", "Rg", "Cn", "Nh", "FI", "Mc", "Lv", "Ts", "Og" };
            string word = "frenchfries";
            var p = new Spelling(word, elementSymbol);
            p.PrintResult(word, elementSymbol);
        }
    }
    class Spelling
    {
        string _word;
        List<string> _elementSymbol;
        public Spelling(string word, List<string> elementSymbol)
        {
            _word = word;
            _elementSymbol = elementSymbol;
        }
        public void PrintResult(string word, List<string> elementSymbol)
        {
            var result = new Stack<string>();
            if (CanSpellUsingElementSymbol(word, elementSymbol,result))
            {
                Console.Write($"Yes, {word} can be spelled out using element symbols.");
            }
            else
            {
                Console.Write($"No, {word} can't be spelled out using element symbols.");
            }
        }
        public bool CanSpellUsingElementSymbol(string word, List<string> elementSymbol, Stack<string> result)
        {
            if (word.Length == 0)
            {
                return true;
            }
            for (int i = 0; i < word.Length; i++)
            {
                if (i != 0)
                {
                    if (elementSymbol.Contains(UppercaseFirstLetter(word[i - 1].ToString()) + word[i]))
                    {
                        result.Push(word[i].ToString());
                        result.Push(word[i - 1].ToString());
                        if (CanSpellUsingElementSymbol(word.Substring(i + 1),elementSymbol, result))
                        {
                            return true;
                        }
                        result.Pop();
                    }
                    return false;
                }
                else if (elementSymbol.Contains(UppercaseFirstLetter(word[i].ToString())))
                {
                    result.Push(word[i].ToString());
                    if (CanSpellUsingElementSymbol(word.Substring(i + 1), elementSymbol, result))
                    {
                        return true;
                    }
                    result.Pop();
                }
            }
            return false;
        }
        public string UppercaseFirstLetter(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
