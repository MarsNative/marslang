using System;
using Xunit;

namespace MarsLang.Compiler.Tests
{
    public class PackageDeclTest
    {
        [Theory]
        [InlineData("package demo;")]
        [InlineData("package demo.test;")]
        [InlineData("package demo")]
        [InlineData("package demo.test")]
        public void ValidPackageDecl(string code)
        {
            var packageDeclContext = TestParserUtil.ParsePackage(code);
            Assert.Null(packageDeclContext.exception);
        }
        
        [Theory]
        [InlineData("package 32343")]
        [InlineData("package ____")]
        [InlineData("package @#$")]
        [InlineData("package;")]
        [InlineData("package/")]
        [InlineData("package ;")]
        public void InvalidPackageDecl(string code)
        {
            Assert.Throws<Exception>(() => TestParserUtil.ParsePackage(code));
        }
    }
}