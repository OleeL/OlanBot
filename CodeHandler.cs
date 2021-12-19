namespace OlanBot
{
    public class CodeHandler
    {
        public string LinkConverter(string name) => name switch
        {
            "java" => "java",
            "python" => "python",
            "c" => "C",
            "c++" => "cpp",
            "cpp" => "cpp",
            "nodejs" => "NodeJS",
            "javascript" => "JavaScript",
            "groovy" => "Groovy",
            "jshell" => "JShell",
            "haskell" => "Haskell",
            "tcl" => "Tcl",
            "lua" => "Lua",
            "ada" => "Ada",
            "commonlisp" => "CommonLisp",
            "d" => "D",
            "elixir" => "Elixir",
            "erlang" => "Erlang",
            "f#" => "fsharp",
            "fortran" => "Fortran",
            "assembly" => "Assembly",
            "scala" => "Scala",
            "php" => "Php",
            "python2" => "Python2",
            "c#" => "C#",
            "perl" => "Perl",
            "ruby" => "Ruby",
            "go" => "Go",
            "r" => "R",
            "racket" => "Racket",
            "ocaml" => "OCaml",
            "vb" => "vb",
            "visualbasic" => "visualbasic",
            "bash" => "Bash",
            "clojure" => "Clojure",
            "typescript" => "TypeScript",
            "cobol" => "Cobol",
            "kotlin" => "Kotlin",
            "pascal" => "Pascal",
            "prolog" => "Prolog",
            "rust" => "Rust",
            "swift" => "Swift",
            "octave" => "Octave",
            "html" => "HTML",
            "materialize" => "Materialize",
            "bootstrap" => "Bootstrap",
            "foundation" => "Foundation",
            "bulma" => "Bulma",
            "uikit" => "Uikit",
            "semantic UI" => "Semantic UI",
            "skeleton" => "Skeleton",
            "milligram" => "Milligram",
            "papercss" => "PaperCSS",
            "mysql" => "MySQL",
            "postgresql" => "PostgreSQL",
            "mongodb" => "MongoDB",
            "sqlite" => "SQLite",
            "redis" => "Redis",
            "mariadb" => "MariaDB",
            _ => "",
        };
        
        public CodeHandler()
        {
            
        }
        
        
    }
}