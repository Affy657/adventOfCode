using FluentAssertions;
using Lib.Day07Year2023;
using Lib.Day08Year2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Algo2023Day08Tests
{
    public class NodeBuilderTest
    {
        [Fact]

        public void NodeNameListBuilder_GivenCorectInput_ShouldBeCorectValue()
        {
            // Given           
            NodeBuilder nodeBuilder = new NodeBuilder();

            // When
            List<Node> actual = nodeBuilder.NodeNameListBuilder(["AAA = (BBB, BBB)","BBB = (AAA, ZZZ)","ZZZ = (ZZZ, ZZZ)"]);           

            // Then
            actual.Should().NotBeEmpty();
            actual.Count.Should().Be(3);
            actual[0].Name.Should().BeEquivalentTo("AAA");           
            
        }

        [Fact]

        public void NodeListBuilder_GivenCorectInput_ShouldBeCorectValue()
        {
            // Given           
            NodeBuilder nodeBuilder = new NodeBuilder();
            string[] rawInput = ["AAA = (BBB, BBB)", "BBB = (AAA, ZZZ)", "ZZZ = (ZZZ, ZZZ)"];
            List<Node> nodesNameList = nodeBuilder.NodeNameListBuilder(rawInput);

            // When
            List<Node> actual = nodeBuilder.NodeListBuilder(rawInput, nodesNameList);

            // Then
            actual.Should().NotBeEmpty();
            actual.Count.Should().Be(3);
            actual[0].Name.Should().BeEquivalentTo("AAA");
            actual[0].Links[0].Should().BeSameAs(actual[1]);
            actual[2].Links[0].Should().BeSameAs(actual[2]);

        }
        [Fact]
        public void NodeListBuilder_GivenCorectInput_ShouldBeCorectLinks()
        {
            // Given           
            NodeBuilder nodeBuilder = new NodeBuilder();
            string[] rawInput = ["AAA = (BBB, BBB)", "BBB = (AAA, ZZZ)", "ZZZ = (ZZZ, ZZZ)"];
            List<Node> nodesNameList = nodeBuilder.NodeNameListBuilder(rawInput);

            // When
            List<Node> actual = nodeBuilder.NodeListBuilder(rawInput, nodesNameList);


            // Then

            actual[0].Links[0].Name.Should().BeSameAs(actual[1].Name);
            actual[0].Links[1].Name.Should().BeSameAs(actual[1].Name);
            actual[1].Links[0].Name.Should().BeSameAs(actual[0].Name);
            actual[1].Links[1].Name.Should().BeSameAs(actual[2].Name);
            actual[2].Links[0].Name.Should().BeSameAs(actual[2].Name);
            actual[2].Links[1].Name.Should().BeSameAs(actual[2].Name);

        }
    }
}
