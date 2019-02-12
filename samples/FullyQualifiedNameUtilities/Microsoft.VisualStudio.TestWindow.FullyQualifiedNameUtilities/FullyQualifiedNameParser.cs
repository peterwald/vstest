﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Microsoft.VisualStudio.TestWindow.FullyQualifiedNameUtilities
{
    public class FullyQualifiedNameParser
    {
        public static void ParseTypeName(string fullTypeName, out string namespaceName, out string typeName)
        {
            int pos = fullTypeName.LastIndexOf('.');
            if (pos == -1)
            {
                namespaceName = string.Empty;
                typeName = fullTypeName;
            }
            else
            {
                namespaceName = fullTypeName.Substring(0, pos);
                typeName = fullTypeName.Substring(pos + 1);
            }
        }

        public static void ParseMethodName(string fullMethodName, out string methodName, out int arity, out string[] parameterTypes)
        {
            int pos = ParseMethodName(fullMethodName, 0, out methodName, out arity);
            pos = ParseParameterTypeList(fullMethodName, pos, out parameterTypes);
            if (pos != fullMethodName.Length)
            {
                string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorUnexpectedCharactersAtEnd, pos);
                throw new InvalidQualifiedNameException(message);
            }
        }

        private static string Capture(string fullMethodName, int start, int end)
            => fullMethodName.Substring(start, end - start);

        private static int ParseMethodName(string fullMethodName, int start, out string methodName, out int arity)
        {
            int i = start;
            for (; i < fullMethodName.Length; i++)
            {
                switch (fullMethodName[i])
                {
                    case var w when char.IsWhiteSpace(w):
                        string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorWhitespaceNotValid, i);
                        throw new InvalidQualifiedNameException(message);
                    case '`':
                        methodName = Capture(fullMethodName, start, i);
                        return ParseArity(fullMethodName, i, out arity);
                    case '(':
                        methodName = Capture(fullMethodName, start, i);
                        arity = 0;
                        return i;
                }
            }
            methodName = Capture(fullMethodName, start, i);
            arity = 0;
            return i;
        }

        // parse arity in the form `nn where nn is an integer value.
        private static int ParseArity(string fullMethodName, int start, out int arity)
        {
            arity = 0;
            Debug.Assert(fullMethodName[start] == '`');

            int i = start + 1; // skip initial '`' char
            for (; i < fullMethodName.Length; i++)
            {
                if (fullMethodName[i] == '(') break;
            }
            if (!int.TryParse(Capture(fullMethodName, start + 1, i), out arity))
            {
                string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorMethodArityMustBeNumeric);
                throw new InvalidQualifiedNameException(message);
            }
            return i;
        }

        private static int ParseParameterTypeList(string fullMethodName, int start, out string[] parameterTypes)
        {
            parameterTypes = null;
            if (start == fullMethodName.Length)
            {
                return start;
            }
            Debug.Assert(fullMethodName[start] == '(');

            var types = new List<string>();

            int i = start + 1; // skip initial '(' char
            for (; i < fullMethodName.Length; i++)
            {
                switch (fullMethodName[i])
                {
                    case ')':
                        if (types.Any())
                        {
                            parameterTypes = types.ToArray();
                        }
                        return i + 1; // consume right parens
                    case ',':
                        break;
                    default:
                        i = ParseParameterType(fullMethodName, i, out var parameterType);
                        types.Add(parameterType);
                        break;
                }
            }

            string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorIncompleteFullyQualifiedName);
            throw new InvalidQualifiedNameException(message);
        }

        private static int ParseParameterType(string fullMethodName, int start, out string parameterType)
        {
            parameterType = string.Empty;

            int i = start;
            for (; i < fullMethodName.Length; i++)
            {
                switch (fullMethodName[i])
                {
                    case '<':
                        i = ParseGenericBrackets(fullMethodName, i + 1);
                        break;
                    case '[':
                        i = ParseArrayBrackets(fullMethodName, i + 1);
                        break;
                    case ',':
                    case ')':
                        parameterType = Capture(fullMethodName, start, i);
                        return i - 1;
                    case var w when char.IsWhiteSpace(w):
                        string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorWhitespaceNotValid, i);
                        throw new InvalidQualifiedNameException(message);
                }
            }
            return i;
        }

        private static int ParseArrayBrackets(string fullMethodName, int start)
        {
            for (int i = start; i < fullMethodName.Length; i++)
            {
                switch (fullMethodName[i])
                {
                    case ']':
                        return i;
                    case var w when char.IsWhiteSpace(w):
                        string msg = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorWhitespaceNotValid, i);
                        throw new InvalidQualifiedNameException(msg);
                }
            }

            string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorIncompleteFullyQualifiedName);
            throw new InvalidQualifiedNameException(message);
        }

        private static int ParseGenericBrackets(string fullMethodName, int start)
        {
            for (int i = start; i < fullMethodName.Length; i++)
            {
                switch (fullMethodName[i])
                {
                    case '<':
                        i = ParseGenericBrackets(fullMethodName, i + 1);
                        break;
                    case '>':
                        return i;
                    case var w when char.IsWhiteSpace(w):
                        string msg = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorWhitespaceNotValid, i);
                        throw new InvalidQualifiedNameException(msg);
                }
            }

            string message = string.Format(CultureInfo.CurrentCulture, FullyQualifiedNameMessages.ErrorIncompleteFullyQualifiedName);
            throw new InvalidQualifiedNameException(message);
        }
    }
}