using Xunit;

namespace MarsLang.Compiler.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestEmptyFunction()
        {
            const string emptyFunction = "func main() { }";

            var functionContext = TestParserUtil.ParseFunction(emptyFunction);
            Assert.Equal(functionContext.simpleName().GetText(), "main");
            Assert.Null(functionContext.parameterList());
            Assert.Empty(functionContext.functionBody().expression());
        }
        
        [Fact]
        public void TestSingleParameterFunction()
        {
            const string singleParamFunction = "func main(args [String]) { }";

            var functionContext = TestParserUtil.ParseFunction(singleParamFunction);
            Assert.Equal(functionContext.simpleName().GetText(), "main");
            Assert.Equal(functionContext.parameterList().parameterDef().Length, 1);

            var parameterDefContexts = functionContext.parameterList().parameterDef();
            var parameter = parameterDefContexts[0];
            
            Assert.Equal(parameter.IDENTIFIER().GetText(), "args");
            Assert.Equal(parameter.typeRef().listRef().fqName().GetText(), "String");
            Assert.Empty(functionContext.functionBody().expression());
        }
        
        [Fact]
        public void TestTwoParameterFunction()
        {
            const string function = "func add(v1 Int, v2 Float) { }";

            var functionContext = TestParserUtil.ParseFunction(function);
            Assert.Equal(functionContext.simpleName().GetText(), "add");
            Assert.Equal(functionContext.parameterList().parameterDef().Length, 2);

            var parameterDefContexts = functionContext.parameterList().parameterDef();
            
            var parameter = parameterDefContexts[0];
            Assert.Equal(parameter.IDENTIFIER().GetText(), "v1");
            Assert.Equal(parameter.typeRef().fqName().GetText(), "Int");
            
            parameter = parameterDefContexts[1];
            Assert.Equal(parameter.IDENTIFIER().GetText(), "v2");
            Assert.Equal(parameter.typeRef().fqName().GetText(), "Float");
            
            Assert.Empty(functionContext.functionBody().expression());
        }
        
        [Fact]
        public void TestGenericParameter()
        {
            const string function = "func doSomething(theObj GenericType<String>) { }";

            var functionContext = TestParserUtil.ParseFunction(function);
            Assert.Equal(functionContext.simpleName().GetText(), "doSomething");
            Assert.Equal(functionContext.parameterList().parameterDef().Length, 1);

            var parameterDefContexts = functionContext.parameterList().parameterDef();
            
            var parameter = parameterDefContexts[0];
            Assert.Equal(parameter.IDENTIFIER().GetText(), "theObj");
            
            var genericType = parameter.typeRef().genericTypeRef();
            
            Assert.Equal(genericType.fqName().GetText(), "GenericType");
            var firstParameter = genericType.genericParameterList().typeRef();
            Assert.Equal(firstParameter[0].GetText(), "String");
            
            Assert.Empty(functionContext.functionBody().expression());
        }
    }
}