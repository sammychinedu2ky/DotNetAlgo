using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAlgo.Trees
{
    internal class Tries
    {
        public TriesNode Root { get; set; }

        public Tries()
        {
            Root = new TriesNode("");
            var listOfWords = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Trees", "Data.json")));
            listOfWords.ForEach(i =>
            {
                Root.Add(i);
            });
        }
        public List<string> Complete(string word)
        {
            return Root.Complete(word);
        }
    }
    internal class TriesNode
    {
        public List<TriesNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }
        public string Value { get; set; }

        public TriesNode(string word)
        {
            Children = new List<TriesNode>();
            IsEndOfWord = false;
            Value = String.IsNullOrEmpty(word) ? "" : word[0].ToString().ToLower();
            if (word.Length > 1)
            {
                Children.Add(new TriesNode(word.Substring(1)));
            }
            else
            {
                IsEndOfWord = true;
            }
        }

        public void Add(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                return;
            }
            else
            {
                var firstLetter = word.ToLower()[0].ToString();
                var remainingLetters = word.Substring(1);
                for (var i = 0; i < Children.Count; i++)
                {
                    var child = Children[i];
                    if (child.Value == firstLetter)
                    {
                        if (!string.IsNullOrEmpty(remainingLetters))
                        {
                            child.Add(remainingLetters);
                        }
                        else
                        {
                            IsEndOfWord = true;
                        }
                        return;
                    }

                }
                Children.Add(new TriesNode(word));
            }

        }

        private List<string> _complete(string search, string builtWord, List<string> suggestions)
        {
           
            if (suggestions.Count >= 3 || (!string.IsNullOrEmpty(search) && search[0].ToString() != Value))
            {
                return suggestions;
            }
            if (IsEndOfWord)
            {
                suggestions.Add(builtWord + Value);
            }

            Children.ForEach(child =>
            {
                child._complete(search.Length>1?search.Substring(1):"", builtWord + Value, suggestions);
            });
            return suggestions;
        }
        public List<string> Complete(string word)
        {
            var suggestions = new List<string>();
            suggestions.AddRange(this._complete(word, "", new List<string>()).ToList());
            foreach (var item in Children)
            {
                suggestions.AddRange(item._complete(word, "", new List<string>()));
            }
            return suggestions;
        }
    }
}
