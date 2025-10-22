![Compiler Banner] (Full Project/ScannerandParser.png)

# 🧩 Full Compiler Project — Scanner + Parser  

<p align="center">
  <img src="https://img.shields.io/badge/version-3.0.0-8e44ad.svg?style=flat-square&logo=github&logoColor=white" alt="Version Badge" />
  <img src="https://img.shields.io/badge/Language-C%23-9b59b6.svg?style=flat-square&logo=csharp&logoColor=white" alt="C# Badge" />
</p>

This project implements both the **Lexical Analysis (Scanner)** and **Syntax Analysis (Parser)** stages of a compiler.  
It reads source code, generates tokens, validates syntax using a formal grammar, and displays results in structured, colored console output with optional parse tree visualization.

> 🧠 Developed by **Abdalla Samir** - **Ahmed Diaa** – **Mohammed Khaled** - Faculty of Computers and Artificial Intelligence, Assiut National University  
> 📚 Course: **Compiler Construction – 3rd Level (2025)**  

---

## 🚀 Overview

This compiler simulates the **front-end phases** of compilation:

| Stage | Description |
|--------|-------------|
| **Scanner (Lexical Analyzer)** | Converts raw source code into tokens. Detects errors like Arabic or non-ASCII input. |
| **Parser (Syntax Analyzer)** | Validates the sequence of tokens against grammar rules using recursive descent parsing. Builds a parse tree for visualization. |

---

## ⚙️ Features

### 🔹 Lexical Analysis
- Recognizes **keywords**, **identifiers**, **numbers**, **operators**, **delimiters**, and **comments**.
- Tracks **line** and **column** positions for each token.
- Flags **Arabic / non-ASCII** characters as lexical errors.
- Colored console output per token type.
- Saves results to `tokens_output.txt`.

### 🔹 Syntax Analysis
- Implements **Recursive Descent Parser**.
- Checks syntax against formal grammar.
- Reports errors with line/column reference.
- Builds a **Parse Tree** and optionally saves it.
- Accepts both file and manual input.

---

## 🧩 Grammar Rules

### 📘 Regular Expressions
```
Digit       = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
Unsigned    = Digit Digit*
Integer     = (- | ε) Unsigned
Real        = Integer (ε | . Integer)
Num         = Real | Integer
Letter      = A | ... | Z | a | ... | z
ID          = Letter (Letter | Digit)*
```

### 📗 Tokens
```
==  !=  =  <=  >=
<   >   ;  ,  (  )
[   ]   {  }  +  -  *  /
void  real  int  return  if  else  while
Num  ID
```

### 📙 Grammar
```
program             → declaration-list
declaration-list    → declaration declaration-list | declaration
declaration         → var-declaration | fun-declaration
var-declaration     → type-specifier ID ; | type-specifier ID [ Num ] ;
type-specifier      → int | real | void
fun-declaration     → ID type-specifier ( params ) compound-stmt
params              → param-list | ε
param-list          → param param-list | param
param               → type-specifier ID | type-specifier ID [ ]
compound-stmt       → { local-declarations stmt-list }
local-declarations  → var-declaration local-declarations | ε
stmt-list           → statement stmt-list | ε
statement           → expression-stmt | compound-statement |
                       selection-statement | iteration-statement | return-statement
expression-stmt     → expression ; | ;
selection-statement → if ( expression ) statement |
                       if ( expression ) statement else statement
iteration-statement → while ( expression ) statement
return-stmt         → return ; | return expression ;
expression          → var = expression | simple-expression
var                 → ID | ID [ expression ]
simple-expression   → additive-expression relOp additive-expression |
                       additive-expression
relOp               → <= | >= | < | > | != | ==
additive-expression → term addOp additive-expression | term
addOp               → + | -
term                → factor mulOp term | factor
mulOp               → * | /
factor              → ( expression ) | var | call | Num
call                → ID ( args )
args                → args-list | ε
args-list           → expression , args-list | expression
```

---

## 💡 Example Input

```tiny
int x;
x = 5;
while (x > 0) {
  x = x - 1;
}
```

### ✅ Output (Simplified)
```
Lexical Analysis Complete ✔️
[1:1-3] ReservedWord: int
[1:5-5] Identifier: x
[1:6-6] Semicolon: ;

Syntax Analysis Complete ✔️
Program Parsed Successfully
Parse Tree Generated 🌲
```

---

## 📂 Project Structure

| File/Class               | Description |
|--------------------------|-------------|
| `Program.cs`             | Entry point |
| `ScannerController.cs`   | Manages lexical analysis |
| `ParserController.cs`    | Controls parsing and error reporting |
| `Scanner.cs`             | Core scanning/tokenization logic |
| `Parser.cs`              | Implements recursive descent parser |
| `Node.cs`                | Parse tree node definition |
| `Token.cs`               | Token class with type, value, position |
| `TokenType.cs`           | Enum for all token types |
| `ParseTreeVisualizer.cs` | Builds and prints syntax tree |
| `ReservedWordsManager.cs`| Recognizes keywords |
| `ResultSaver.cs`         | Exports results to files |

---

## 🧭 How to Run

### Prerequisites
- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)

### Build & Execute
```bash
dotnet build
dotnet run
```

### Input Modes
- Manual entry: Type code directly.
- File input: Enter file path when prompted.

---

## 📁 Outputs
| File | Description |
|------|--------------|
| `tokens_output.txt` | All tokens and their types |
| `syntax_result.txt` | Syntax validation report |
| `parse_tree.txt` | Text-based parse tree |

---

## 🧱 Future Enhancements
- [ ] Semantic analysis (type checking)
- [ ] Intermediate code generation
- [ ] Optimization phase simulation
- [ ] GUI interface for visualization
- [ ] VS Code / IDE plugin

---

## 🙏 Acknowledgments
- **Prof. Amal Abdelazim** – Project Supervision  
- **Eng. Walid Mamdouh** – Technical Guidance

---

## 📧 Contact

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/abdalla-samir-9264242b6/)  
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:samirovic707@gmail.com)  
[![Telegram](https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white)](https://t.me/abdallasamir04)

---

**Abdalla Mahmoud Samir**  
Faculty of Computers and Artificial Intelligence  
Assiut National University  
Compiler Construction – Third Level  
October 2025
