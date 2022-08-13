﻿using Blazor.Diagrams;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Models;
using SharedDemo.Demos.Nodes;

namespace SharedDemo.Demos.CustomSvgGroup
{
    partial class Demo
    {
        private readonly Diagram _diagram = new Diagram();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            LayoutData.Title = "Custom SVG group";
            LayoutData.Info = "Creating your own custom svg groups is very easy!";
            LayoutData.DataChanged();

            _diagram.RegisterModelComponent<CustomSvgGroupModel, CustomSvgGroupWidget>();
            _diagram.RegisterModelComponent<SvgNodeModel, SvgNodeWidget>();

            var node1 = NewNode(50, 50);
            var node2 = NewNode(300, 300);
            var node3 = NewNode(500, 100);

            _diagram.Nodes.Add(new[] { node1, node2, node3 });
            _diagram.AddGroup(new CustomSvgGroupModel(new[] { node2, node3 }, "Group 1"));

            _diagram.Links.Add(new LinkModel(node1.GetPort(PortAlignment.Right), node2.GetPort(PortAlignment.Left)));
            _diagram.Links.Add(new LinkModel(node2.GetPort(PortAlignment.Right), node3.GetPort(PortAlignment.Left)));
        }

        private NodeModel NewNode(double x, double y)
        {
            var node = new SvgNodeModel(new Point(x, y));
            node.AddPort(PortAlignment.Bottom);
            node.AddPort(PortAlignment.Top);
            node.AddPort(PortAlignment.Left);
            node.AddPort(PortAlignment.Right);
            return node;
        }
    }
}
