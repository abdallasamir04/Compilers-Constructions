using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScannerParserProject
{
    public partial class Form1 : Form
    {
        private Scanner scanner;
        private Parser parser;

        public Form1()
        {
            InitializeComponent();
            scanner = new Scanner();
            parser = new Parser();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            try
            {
                List<Token> tokens = scanner.Scan(input);
                DisplayTokens(tokens);
            }
            catch (Exception ex)
            {
                txtOutput.Text = "Scanning Error: " + ex.Message;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            try
            {
                // First, scan the input to get tokens
                List<Token> tokens = scanner.Scan(input);

                // Clear the output
                txtOutput.Clear();

                // Add debugging information
                txtOutput.AppendText($"Found {tokens.Count} tokens\r\n\r\n");

                // Try to parse
                bool success = parser.Parse(tokens);

                // Display parse tree regardless of success
                txtOutput.AppendText("PARSE TREE:\r\n");
                txtOutput.AppendText("==================================================\r\n");
                txtOutput.AppendText(parser.GetParseTree());

                if (success)
                {
                    txtOutput.AppendText("\r\n==================================================\r\n");
                    txtOutput.AppendText("Parsing completed successfully.");
                }
            }
            catch (Exception ex)
            {
                // Display the error with stack trace for debugging
                txtOutput.Text = "Parsing Error: " + ex.Message + "\r\n\r\n";
                txtOutput.AppendText("Stack Trace:\r\n" + ex.StackTrace);
            }
        }

        private void DisplayTokens(List<Token> tokens)
        {
            txtOutput.Clear();
            txtOutput.AppendText("TOKENS:\r\n");
            txtOutput.AppendText("==================================================\r\n");
            txtOutput.AppendText(String.Format("{0,-15} {1,-15} {2}\r\n", "TOKEN TYPE", "LEXEME", "POSITION"));
            txtOutput.AppendText("--------------------------------------------------\r\n");

            foreach (Token token in tokens)
            {
                txtOutput.AppendText(String.Format("{0,-15} {1,-15} {2}\r\n",
                    token.Type, token.Lexeme, token.Position));
            }
        }

        private void btnLoadExample_Click(object sender, EventArgs e)
        {
            txtInput.Text = @"int factorial(int n) {
  if (n <= 1) {
    return 1;
  } else {
    return n * factorial(n-1);
  }
}

void main() {
  int result;
  result = factorial(5);
}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
        }
    }
}