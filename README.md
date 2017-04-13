# Test2

The task is to write a program that imports a list of books, read from a text file with the following template:

[Format Indicator]
NAME ISBN AUTHOR
NAME ISBN AUTHOR
..
NAME ISBN AUTHOR

Right now, there are two file formats:

A.

NAME: starts from column 1 ends at 20,

ISBN: starts from column 21 ends at 41,

AUTHOR: starts from column 42 ends at 62.

B.

NAME: starts from column 1 ends at 30,

ISBN: starts from column 31 ends at 51,

AUTHOR: starts from column 52 ends at 72.

There is a sample file of each format attached. The first line of the file indicates which type it is, subsequent rows contain book data.
