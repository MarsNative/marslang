
grammar Mars;

/*
==================
PARSER RULES
==================
*/

compilationUnit: packageDecl? (functionDef|typeDef)* EOF;

packageDecl: KW_PACKAGE packageName SYM_SEMICOLON?;

packageName
    : IDENTIFIER
    | packageName SYM_DOT IDENTIFIER
    ;

simpleName
    : IDENTIFIER
    ;

fqName
    : IDENTIFIER
    | fqName SYM_DOT IDENTIFIER
    ;

functionDef
    : KW_FUNC simpleName SYM_LPAREN (parameterList?) SYM_RPAREN typeRef? SYM_LBRACE functionBody SYM_RBRACE
    ;

parameterList
    : parameterDef (SYM_COMMA parameterDef)*
    ;

parameterDef
    : IDENTIFIER typeRef
    ;

typeRef
    : listRef
    | genericTypeRef
    | fqName
    ;

listRef
    : SYM_LBRACKET fqName SYM_RBRACKET
    ;

genericTypeRef
    : fqName SYM_LANGLE genericParameterList SYM_RANGLE
    ;

genericParameterList
    : typeRef (SYM_COMMA typeRef)*;

typeDef
    : KW_TYPE simpleName (SYM_LBRACE SYM_RBRACE)?
    ;

functionBody: (expression SYM_SEMICOLON?)*;

expression: reference | literal;

reference: IDENTIFIER;
literal: INTEGER;

binaryOp: expression OPERATOR expression;


/*
==================
LEXER RULES
==================
*/

// fragments
fragment DIGIT          : [0-9];
fragment LETTER         : [a-zA-Z];
fragment LC_LETTER      : [a-z];
fragment UC_LETTER      : [A-Z];

WS : [ \n\r\t\u000B\u000C\u0000]+				-> channel(HIDDEN) ;
BLOCK_COMMENT : '/*' (BLOCK_COMMENT|.)*? '*/'	-> channel(HIDDEN) ; // nesting comments allowed
LINE_COMMENT : '//' .*? ('\n'|EOF)				-> channel(HIDDEN) ;

KW_PACKAGE:     'package';
KW_FUNC:        'func';
KW_TYPE:        'type';

SYM_LPAREN:     '(';
SYM_RPAREN:     ')';
SYM_LBRACE:     '{';
SYM_RBRACE:     '}';
SYM_LBRACKET:   '[';
SYM_RBRACKET:   ']';
SYM_LANGLE:     '<';
SYM_RANGLE:     '>';
SYM_COMMA:      ',';
SYM_SEMICOLON:  ';';
SYM_DOT:        '.';

IDENTIFIER: LETTER+(DIGIT|LETTER)*;

INTEGER: DIGIT+;

ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';

OPERATOR: ADD |
            SUB |
            MUL |
            DIV;