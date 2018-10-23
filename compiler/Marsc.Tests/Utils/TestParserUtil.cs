using System;
using System.IO;
using Antlr4.Runtime;

namespace MarsLang.Compiler.Tests
{
    public static class TestParserUtil
    {
        private static MarsParser.CompilationUnitContext ParseCode(string code)
        {
            var inputStream = new AntlrInputStream(code);
            var marsLexer = new MarsLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(marsLexer);
            var marsParser = new MarsParser(commonTokenStream);

            marsParser.AddErrorListener(new ErrorListener());

            var compilationUnit = marsParser.compilationUnit();
            return compilationUnit;
        }

        public static MarsParser.PackageDeclContext ParsePackage(string code)
        {
            var compilationUnit = ParseCode(code);
            return compilationUnit.packageDecl();
        }

        public static MarsParser.FunctionDefContext ParseFunction(string code)
        {
            var compilationUnit = ParseCode(code);
            var functionContexts = compilationUnit.functionDef();
            return functionContexts.Length > 0 ? functionContexts[0] : null;
        }
    }

    public class ErrorListener : BaseErrorListener
    {
        public override void SyntaxError(TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            throw new Exception($"Syntax error at {line}, {charPositionInLine}. {msg}");
        }
    }
}