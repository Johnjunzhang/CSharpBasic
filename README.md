CSharpBasic
===========

Learning C Sharp Basic Step by Step. 

##In Brief
We present a story about the teacher in charge of a class, who want to collect the exam scores of his students.

In this story, every step will show you one features of C# language. each steps have a branch, you could checkout like below, 'property_1' is the name of one branch.

>**git branch -r**

>**git checkout property_1**

This program is just for learning C# basic. Beside I also try to use it for introducing the concepts about TDD and refactoring.

###Step 1 - C# Property
You could checkout branch 'property_1', then you can open the file Transcript.cs.

It is a simple C# class, that only has 3 properties; and there is a commented test case, that you should calculate the total score of a transcript.

You could checkout branch 'property_2' to get a example, but it's better to implement it by yourself.

###Step 2 - Extension Method
After checkout to branch 'extension_method_1', you will find there is one more test case. That is print all the courses and their scores for one transcript.

There are many ways you could use to implement it. 

But we hope that you could think about what is static class, method and variable, and what is extension method.

Checkout branch 'extension_method_2', you can see the demo of extension method.

###Step 3 - Nullable Variable
The branch 'nullable_variable_1' shows that we add a property Math in class Transcript, and a test case need you to add the score of math to total score.

if we simple add a int property named Math, therefore if someone's math exam grade is not registered yet, it will be zero; and it might be misunderstanded by other people.

###Step 4 - Reflection
Here we add a test case, that should not the scores of courses, if the score of this course is null.

we could implement it by add few 'if-else', but we try to let people get to know the typeof keyword, and think about what the reflection can do.

###Step 5 - Attribute
If we use reflection to reimplement the Print method, hence the test will fail if we add a new property to Transcript.

How to fix this problem, one solution is identify which property should be print or not. So you need to know something about Attribute.

###Step 6 - Generic
In this commit, we add a new domain type Grade, which store the score of a student. and we want to use the same Print method, but the type of parameter is not even.

Generic will help you to implement it.

###Step 7 - Equal Method
At last commit, we also add a new domain type ExamResult, which store the whole test results of one course.

We need to implement the Add method, which enable you to add someone's Grade in the list of result.

How about the teacher made a mistake, who use the same name for two students.

Shall we check the list when Add a new grade?

###Step 8 - First glance of Linq
In this commit, we add a new method that can convert the exam result to a list of transcripts.

This implementation is weird, the select method I have never saw.

After google it, you will understand what it is, then we should refactor other methods use linq. If you have Resharper, you could simply try alt+enter.

###Step 9 - Delegate
If you want to understand Linq better, you should know delegate at first.

###Step 10 - Lambda
Lambda Expression looks like a elegant syntax for delegation, but it still has some differences.

###Practises
After all the above steps, you may know lots of about C#, you could try to implement some fancy functionalities.

Such as find the best student, calculate the average total score of all the students and so on.