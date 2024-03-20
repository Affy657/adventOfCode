using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Lib.Day07Year2023;

namespace Test.Algo2023Day07Tests
{
    public class BidRankComputeTest
    {
        public static readonly TheoryData<List<HandModel>, List<long>> WhenCorectBidRankCompute_data
            = new TheoryData<List<HandModel>, List<long>>()
            {
                {
                    [new("22222", 1), new("33333", 1), new("44444", 1)],
                    [1,2,3]
                },
                {
                    [new("22222", 1), new("33333", 1), new("44444", 1),new("55555", 1), new("66666", 1), new("77777", 1)],
                    [1,2,3,4,5,6]
                },
                {
                    [new("342QK", 491),new("36QAT", 619),new("85663", 606),new("33K3A", 23),new("K7775", 814),new("T67T6", 105),new("49T8T", 200),new("2KAT2", 317),new("96669", 251)],
                    [491,619*2,606*3,23*4,814*5,105*6,200*7,317*8,251*9]
                }
            };
        
        [Theory]
        [MemberData(nameof(WhenCorectBidRankCompute_data))]
        public void WhenCorectBidRankCompute(List<HandModel> input, List<long> expected)
        {
            TheoryData<List<HandModel>> foo = new TheoryData<List<HandModel>>()
            {
                {
                    [new("22222", 1), new("33333", 1), new("44444", 1)]
                }
            };

            // Given
            BidCalcul bidCalcul = new BidCalcul();
            

            // When
            List<long> actual = bidCalcul.BidRankCompute(input);


            // Then
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
