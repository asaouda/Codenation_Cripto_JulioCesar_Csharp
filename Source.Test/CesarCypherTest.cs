using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0"));
        }
        [Fact]
        public void Should_Keep_DeCrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("the quick brown fox jumps over the lazy dog", cypher.Decrypt("Wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj"));
        }
        [Fact]
        public void Should_Keep_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj", cypher.Crypt("The quick brown fox jumps over the lazy dog"));
        }
    }
}
