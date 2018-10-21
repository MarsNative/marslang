using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Marsc
{
    public class MarsListener : IMarsListener
    {
        public void VisitTerminal(ITerminalNode node)
        {
            throw new System.NotImplementedException();
        }

        public void VisitErrorNode(IErrorNode node)
        {
            throw new System.NotImplementedException();
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            throw new System.NotImplementedException();
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
            throw new System.NotImplementedException();
        }

        public void EnterCompilation_unit(MarsParser.Compilation_unitContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitCompilation_unit(MarsParser.Compilation_unitContext context)
        {
            throw new System.NotImplementedException();
        }

        public void EnterPackage_decl(MarsParser.Package_declContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitPackage_decl(MarsParser.Package_declContext context)
        {
            throw new System.NotImplementedException();
        }

        public void EnterExpression(MarsParser.ExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitExpression(MarsParser.ExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public void EnterReference(MarsParser.ReferenceContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitReference(MarsParser.ReferenceContext context)
        {
            throw new System.NotImplementedException();
        }

        public void EnterLiteral(MarsParser.LiteralContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitLiteral(MarsParser.LiteralContext context)
        {
            throw new System.NotImplementedException();
        }

        public void EnterBinary_op(MarsParser.Binary_opContext context)
        {
            throw new System.NotImplementedException();
        }

        public void ExitBinary_op(MarsParser.Binary_opContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}