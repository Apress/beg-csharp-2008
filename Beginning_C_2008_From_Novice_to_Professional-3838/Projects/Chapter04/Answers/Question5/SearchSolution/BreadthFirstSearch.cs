using System;
using System.Collections.Generic;
using System.Text;

namespace SearchSolution {

    public class BreadthFirstSearch {
        private Node[] _root;
        int _maxPossibleDestinations;

        public BreadthFirstSearch(Node[] root, int maxPossibleDestinations) {
            _root = root;
            _maxPossibleDestinations = maxPossibleDestinations;
        }
        private bool CanContinueSearch(Node[] returnArray, Node city) {
            for (int c1 = 0; c1 < returnArray.Length; c1++) {
                if (returnArray[c1] != null) {
                    if (returnArray[c1].CityName.CompareTo(city.CityName) == 0) {
                        return false;
                    }
                    if (c1 > 2) {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool FindNextLeg(Node[] returnArray, int count, string destination, Node currNode) {
            Console.WriteLine("Count (" + count + ") destination (" + destination + ") Node (" + currNode.CityName + ")");
            if (count > 2) {
                return false;
            }
            for (int c1 = 0; c1 < currNode.Connections.Length; c1++) {
                if (currNode.Connections[c1].CityName.CompareTo(destination) == 0) {
                    returnArray[count] = currNode.Connections[c1];
                    return true;
                }
            }
            for (int c1 = 0; c1 < currNode.Connections.Length; c1++) {
                if (CanContinueSearch(returnArray, currNode.Connections[c1])) {
                    returnArray[count] = currNode.Connections[c1];
                    if (FindNextLeg(returnArray, count + 1, destination, currNode.Connections[c1])) {
                        return true;
                    }
                    else {
                        returnArray[count] = null;
                    }
                }
            }
            return false;
        }
        public Node[] FindRoute(string start, string end) {
            Node[] returnArray = new Node[_maxPossibleDestinations];
            for (int c1 = 0; c1 < _root.Length; c1++) {
                if (_root[c1].CityName.CompareTo(start) == 0) {
                    returnArray[0] = _root[c1];
                    FindNextLeg(returnArray, 1, end, _root[c1]);
                }
            }
            return returnArray;
        }
    }

}
