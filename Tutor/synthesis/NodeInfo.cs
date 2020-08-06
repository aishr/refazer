using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;
using Tutor.ast;

namespace Tutor
{
    public class NodeInfo
    {
        public string NodeType { get; }
        public dynamic NodeValue { get; set; }

        public NodeInfo(string nodeType, dynamic nodeValue)
        {
            NodeType = nodeType;
            NodeValue = nodeValue;
        }

        protected bool Equals(NodeInfo other)
        {
            return string.Equals(NodeType, other.NodeType) && Equals(NodeValue, other.NodeValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NodeInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((NodeType != null ? NodeType.GetHashCode() : 0)*397) ^ (NodeValue != null ? NodeValue.GetHashCode() : 0);
            }
        }

        public NodeInfo(string type)
        {
            NodeType = type;
        }

        public override string ToString()
        {
            return NodeValue == null ? NodeType : NodeType + "-" + NodeValue;
        }

        public static NodeInfo CreateInfo(PythonNode node)
        {
            var type = node.GetType().Name;
            dynamic nodeValue; 
            switch (type)
            {
                case "FunctionDefinitionNode":
                    nodeValue = (node.InnerNode).Name;
                    break;
                case "ConstantExpressionNode":
                    nodeValue = (node.InnerNode).Value;
                    break;
                case "AugmentedAssignStatementNode":
                    nodeValue = (node.InnerNode).Operator;
                    break;
                case "BinaryExpressionNode":
                    nodeValue = (node.InnerNode).Operator;
                    break;
                case "NameExpressionNode":
                    nodeValue = (node.InnerNode).Name;
                    break;
                case "TupleExpressionNode":
                    nodeValue = (node.InnerNode).IsExpandable;
                    break;
                case "ParameterNode":
                    nodeValue = (node.InnerNode).Name;
                    break;
                case "ArgNode":
                case "CallExpressionNode":
                case "LambdaExpressionNode":
                case "SuiteStatementNode":
                case "IfStatementNode":
                case "IfStatementTestNode":
                case "AssignmentStatementNode":
                case "ReturnStatementNode":
                case "ExpressionStatementNode":
                case "WhileStatementNode":
                case "ParenthesisExpressionNode":
                case "ForStatementNode":
                case "ConditionalExpressionNode":
                    nodeValue = null;
                    break;
                default: 
                    throw new NotImplementedException();
            }
            return nodeValue == null ? new NodeInfo(type) : new NodeInfo(type, nodeValue);
        }
    }
}
