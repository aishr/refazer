using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;

namespace Tutor.ast
{
    class OrExpressionNode : InternalNode
    {
        public OrExpressionNode(InnerNode innerNode) : base(innerNode)
        {
            InsertStrategy = new InsertFixedList();
        }

    
        protected override bool IsEqualToInnerNode(InnerNode node)
        {
            throw new NotImplementedException();
        }

        public override PythonNode Clone()
        {
            var pythonNode = new OrExpressionNode(InnerNode);
            pythonNode.Children = Children;
            pythonNode.Id = Id;
            if (Value != null) pythonNode.Value = Value;
            return pythonNode;
        }
    }
}
