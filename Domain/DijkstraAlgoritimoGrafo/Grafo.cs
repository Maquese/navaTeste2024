using Domain.DijkstraAlgoritimoGrafo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DijkstraAlgoritimo
{
    public static class Grafo
    {
        public static Dictionary<string, uint> CalculateShortestPaths(Node startNode, out Dictionary<string, string> previous)
        {
            var distances = new Dictionary<string, uint>();
            var priorityQueue = new SortedSet<(uint distance, Node node)>();
            previous = new Dictionary<string, string>();
            var nodes = new HashSet<Node>();
            Action<Node> collectNodes = null; collectNodes = node =>
            {
                if (!nodes.Contains(node))
                {
                    nodes.Add(node);
                    foreach (var edge in node.Edges)
                    {
                        collectNodes(edge.Destination);
                    }
                }
            };
            collectNodes(startNode);

            foreach (var node in nodes)
            {
                distances[node.Name] = int.MaxValue; previous[node.Name] = null;
            }
            distances[startNode.Name] = 0;
            priorityQueue.Add((0, startNode));
            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentNode) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());
                foreach (var edge in currentNode.Edges)
                {
                    uint newDist = currentDistance + edge.Weight;
                    if (newDist < distances[edge.Destination.Name])
                    {
                        priorityQueue.Remove((distances[edge.Destination.Name], edge.Destination));
                        distances[edge.Destination.Name] = newDist;
                        previous[edge.Destination.Name] = currentNode.Name;
                        priorityQueue.Add((newDist, edge.Destination));
                    }
                }
            }
            return distances;
        }

        public static uint Calcular(List<Rota> rotas, string origin, string destination)
        {
            origin = origin.Trim();
            destination = destination.Trim();
            var nodes = new Dictionary<string, Node>();
            foreach (var rota in rotas)
            {
                if (!nodes.ContainsKey(rota.Origem))
                {
                    nodes[rota.Origem] = new Node { Name = rota.Origem };
                }
                if (!nodes.ContainsKey(rota.Destino)) { nodes[rota.Destino] = new Node { Name = rota.Destino }; }
            } // Adicionar arestas aos nós
            foreach (var rota in rotas)
            {
                nodes[rota.Origem].Edges.Add(new Edge { Destination = nodes[rota.Destino], Weight = rota.Valor });
            }
            if (!nodes.ContainsKey(origin) || !nodes.ContainsKey(destination))
            {
                throw new ArgumentOutOfRangeException("Origem ou destino inválido.");
            } // Calcular o menor caminho usando Dijkstra
            var shortestPaths = CalculateShortestPaths(nodes[origin], out var previous);
            // Reconstruir o caminho
            var path = new List<string>(); for (var at = destination; at != null; at = previous[at]) { path.Add(at); }
            path.Reverse();

            return shortestPaths[destination];
        }
    }
}
