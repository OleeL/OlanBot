using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using OlanBot.Models;
using OlanBot.Models.DTOs.JDoodle;
using OlanBot.Services;

namespace OlanBot
{
    public static class CodeMappings
    {
        public static string Map(string language) => language.ToLower() switch
        {
            "c++" => "cpp17",
            "cpp" => "cpp17",
            "hpp" => "cpp17",
            "c#" => "csharp",
            "cs" => "csharp",
            "erl" => "erlang",
            "h" => "c",
            "python" => "python3",
            "py" => "python3",
            "golang" => "go",
            "sh" => "bash",
            "f90" => "fortran",
            "bf" => "brainfuck",
            "vb" => "vbn",
            "javascript" => "nodejs",
            "js" => "nodejs",
            "objectivec" => "objc",
            "mm" => "objc",
            "hs" => "haskell",
            _ => language
        };
    }
}