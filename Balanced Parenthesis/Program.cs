// This program will check that parentheses of input string are balanced.
using System;
using System.Collections.Generic;

public class Balancedparentheses
{
    /// <summary>
    /// Checks that two input braces are matches.
    /// </summary>
    /// <param name="char1"></param>
    /// <param name="char2"></param>
    /// <returns>Boolean</returns>
    public static Boolean IsMatchingPair(char char1, char char2)
    {
        if (char1 == '(' && char2 == ')')
            return true;
        else if (char1 == '{' && char2 == '}')
            return true;
        else if (char1 == '[' && char2 == ']')
            return true;
        else return false;
    }

    /// <summary>
    /// Checks that every open brace has a corresponding closing brace.
    /// </summary>
    /// <param name="strIn"></param>
    /// <returns>Boolean</returns>
    public static Boolean AreParenthesesBalanced(string strIn)
    {
        Stack<char> s = new Stack<char>(); // Will hold braces to check that each one has a closing brace

        for (int i = 0; i < strIn.Length; i++)
        {
            if (strIn[i] == '(' || strIn[i] == '{' || strIn[i] == '[')
                s.Push(strIn[i]);
            
            if (strIn[i] == ')' || strIn[i] == '}' || strIn[i] == ']')
            {
                if (s.Count == 0)   // If stack is empty, then no previous brace needs to end
                    return false;   // Not balanced
                else if (!IsMatchingPair(s.Pop(), strIn[i]))    // If previous brace does not match new brace
                    return false;                               // Not balanced
            }
        }

        if (s.Count == 0)   // If stack is empty after the string has been read
            return true;    // Balanced
        else                // If stack is not empty, some brace did not end
            return false;   // Not balanced
    }

    /// <summary>
    /// Checks that input string has balanced braces.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(String[] args)
    {
        string str = "(a(b(c))[)df[]]f)";

        if (AreParenthesesBalanced(str))
            Console.WriteLine("Balanced");
        else
            Console.WriteLine("Not Balanced");
    }
}
