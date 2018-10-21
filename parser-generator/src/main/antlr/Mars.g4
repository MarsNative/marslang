
grammar Mars;

/*
==================
PARSER RULES
==================
*/

compilation_unit: package_decl;

package_decl: KW_PACKAGE IDENTIFIER;

expression: reference | literal;

reference: IDENTIFIER;
literal: INTEGER;

binary_op: expression OPERATOR expression;


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

KW_PACKAGE: 'package';

IDENTIFIER: LETTER+(DIGIT*LETTER*)?;

INTEGER: DIGIT+;

ADD: '+';
SUB: '-';
MULT: '*';
DIV: '/';

OPERATOR: ADD |
            SUB |
            MULT |
            DIV;