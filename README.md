# ![Compilers Project Background](https://github.com/abdallasamir04/your-repo-name/blob/main/images/DALL·E%202025-03-18%2012.25.00%20-%20A%20sleek%20and%20modern%20background%20image%20for%20a%20compiler%20project%2C%20featuring%20a%20combination%20of%20gears%2C%20computer%20code%2C%20and%20abstract%20shapes%20representing%20technolo.png)

# ⚙️ Compilers Constructions Project: Scanner & Process Stages
# ⚙️ Compilers Constructions Project: Scanner & Process Stages
![Version](https://img.shields.io/badge/version-1.0.0-blue.svg?style=for-the-badge&logo=github&logoColor=white)
![C#](https://img.shields.io/badge/Language-C%23-0078d4.svg?style=for-the-badge&logo=csharp&logoColor=white)


The **Scanner and Process Stages** project is a part of the **Compilers Constructions Project** course.  
This project simulates the development of a **compiler's lexical analysis** stage, focusing on **scanner functionality**. It processes and validates **identifiers** while checking if they are reserved words, and sets the foundation for future compiler stages.  
Developed by **_Abdalla Mahmoud Samir_** as part of the **Compilers Constructions Project** course at **Assiut National University**.

---

## 🚀 Features

### Scanner Functionality
- Scans and validates **identifiers** entered by the user.
- Checks if the identifiers are **reserved words** or **valid user-defined identifiers**.
- Prompts users to continue entering identifiers until they choose to exit.

### Reserved Word Check
- The system has a predefined set of **reserved words** and will flag them as invalid user-defined identifiers.

---

## 🛠️ How It Works

### Identifier Validation
- The **scanner** checks each input to determine if it starts with a letter and is followed by letters or digits.

### Reserved Words Handling
- The **scanner** compares identifiers with a set of reserved words.
- Identifiers that match reserved words are flagged as invalid.

---

## 📜 Commands

The following commands are part of the **scanner** system to handle user inputs:

| Command             | Description                               | Example                  |
|---------------------|-------------------------------------------|--------------------------|
| `Enter identifier`   | Input an identifier for validation        | `Enter identifier: test1` |
| `y`                  | Continue to enter another identifier      | `Do you want to enter another identifier? (y/n): y` |
| `n`                  | Exit the program                          | `Do you want to enter another identifier? (y/n): n` |

---

## 💻 Code Highlights

### Key Methods
| Method                        | Description                                              |
|-------------------------------|----------------------------------------------------------|
| `GetIdentifier(string input)`  | Extracts and returns the identifier from user input.      |
| `IsReservedWord(string identifier)` | Checks if the identifier is part of reserved words.  |
| `IsLetter(char ch)`            | Checks if a character is a letter.                       |
| `IsLetterOrDigit(char ch)`     | Checks if a character is a letter or digit.              |
| `Main()`                       | The entry point of the program that starts the scanner.   |

---

## 📂 Project Structure

### Reserved Words (HashSet)
- Stores all predefined **reserved words** to check for invalid identifiers.

### Scanner Logic
- **Input Handling:** Takes user input for identifiers.
- **Validation:** Checks if the input is a valid identifier and if it matches any reserved word.
- **User Interaction:** Continues prompting the user until they decide to stop.

---

## 📚 Future Stages

### Lexical Analysis
- This project simulates the **lexical analysis** stage of a compiler.
- It involves **scanning** and **tokenizing** input, checking for valid identifiers, and flagging reserved words.

### Next Compiler Stages
- The project will evolve into the next stages of a compiler, including **syntax analysis**, **semantic analysis**, and other components.

---

## 🙏 Acknowledgments

- Prof. Amal Abdelazim - Project supervision.
- Eng. Walid Mamdouh - Technical guidance.

## 📧 Contact

Let's connect! Feel free to reach out or follow me on these platforms:  

[![X (Twitter)](https://img.shields.io/badge/X-black.svg?style=for-the-badge&logo=X&logoColor=white)](https://x.com/abdallasamir04)  
[![Facebook](https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white)](https://www.facebook.com/abdallasamir04/)  
[![Telegram](https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white)](https://t.me/abdallasamir04)  
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/abdalla-mahmoud-9264242b6/)  
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:samirovic707@gmail.com)  
[![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/abdallasamir04)  
---
**Abdalla Mahmoud Samir**  
**Faculty of Computers and Artificial Intelligence**  
**Assiut National University**  
**Compilers Constructions Project Course - Third Level**
