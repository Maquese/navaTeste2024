using NUnit.Framework;
using Domain.DijkstraAlgoritimo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.DijkstraAlgoritimoGrafo;
namespace Domain.Tests
{
        [TestFixture]
        public class GrafoTests
        {
            [Test]
            public void CalculateShortestPaths_DeveCalcularDistanciaCorreta()
            { // Arrange
              var nodeA = new Node { Name = "A" }; 
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            nodeA.Edges.Add(new Edge { Destination = nodeB, Weight = 1 }); 
            nodeB.Edges.Add(new Edge { Destination = nodeC, Weight = 1 });
            nodeA.Edges.Add(new Edge { Destination = nodeC, Weight = 3 });
            // Act
            var previous = new Dictionary<string, string>();
            var distances = Grafo.CalculateShortestPaths(nodeA, out previous);
            // Assert
            Assert.AreEqual(0, distances["A"]);
            Assert.AreEqual(1, distances["B"]); 
            Assert.AreEqual(2, distances["C"]); 
            Assert.AreEqual("A", previous["B"]); 
            Assert.AreEqual("B", previous["C"]);
        } 
        [Test] public void Calcular_DeveCalcularMenorDistancia() 
        { // Arrange
          var rotas = new List<Rota> { new Rota("A", "B", 1), new Rota("B", "C", 1), new Rota("A", "C", 3) }; 
            // Act
            var distancia = Grafo.Calcular(rotas, "A", "C"); 
            // Assert
            Assert.AreEqual(2, distancia); } [Test] public void Calcular_OrigemOuDestinoInvalidos_DeveLancarArgumentOutOfRangeException() { 
            // Arrange
            var rotas = new List<Rota> { new Rota("A", "B", 1), new Rota("B", "C", 1), new Rota("A", "C", 3) }; 
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Grafo.Calcular(rotas, "A", "D"));
        }        
        
    } 
}
            




