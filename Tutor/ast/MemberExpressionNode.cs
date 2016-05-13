﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class MemberExpressionNode : InternalNode
    {
        public MemberExpressionNode(Node innerNode, bool isAbstract) : base(innerNode, isAbstract)
        {
        }

        public MemberExpressionNode(Node innerNode, bool isAbstract, int editId) : base(innerNode, isAbstract, editId)
        {
        }

        protected override bool IsEqualToInnerNode(Node node)
        {
            var comparedNode = node as MemberExpression;
            if (comparedNode == null) return false;
            var inner = (MemberExpression)InnerNode;
            return inner.Name.Equals(comparedNode.Name);
        }

        protected override Tuple<bool, Node> CompareChildren(Node node, Node binding)
        {
            var convertedNode = (MemberExpression)node;
            if (convertedNode == null) return Tuple.Create<bool, Node>(false, null);

            if (Children.Count != 1)
                return Tuple.Create<bool, Node>(false, null);

            var result = Children[0].Match(convertedNode.Target);
            if (!result.Item1)
                return Tuple.Create<bool, Node>(false, null);
            binding = AddBindingNode(binding, result.Item2);
            return Tuple.Create(true, binding);
        }
    }
}