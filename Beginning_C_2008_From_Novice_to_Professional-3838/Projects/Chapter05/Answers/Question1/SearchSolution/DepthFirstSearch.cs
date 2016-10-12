using System;
using System.Collections.Generic;
using System.Text;

namespace SearchSolution {
    // In this solution we don't need exception blocks because
    // we are verifying everything before using it and thus
    // if there is an exception it is because it was unknown and
    // thus should remain an exception.
    public class DepthFirstSearch {
        private Node[] _root;
        int _maxPossibleDestinations;

        public DepthFirstSearch(Node[] root, int maxPossibleDestinations) {
            if (root == null) {
                throw new NullReferenceException("variable root is null");
            }
            for (int c1 = 0; c1 < root.Length; c1++) {
                if (root[c1] == null) {
                    throw new NullReferenceException("one of the array elements is null and thus invalid");
                }
            }
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
            if (currNode.CityName.Length == 0) {
                throw new NullReferenceException("CityName has no length");
            }
            if (currNode.Connections == null) {
                throw new NullReferenceException("Connections for the city (" + currNode.CityName + ") do not exist");
            }
            for (int c1 = 0; c1 < currNode.Connections.Length; c1++) {
                if (currNode.Connections[c1] == null) {
                    throw new NullReferenceException("one of the connections is a null value (" + currNode.CityName + ")");
                }
                if (CanContinueSearch(returnArray, currNode.Connections[c1])) {
                    returnArray[count] = currNode.Connections[c1];
                    if (currNode.Connections[c1].CityName.CompareTo(destination) == 0) {
                        return true;
                    }
                    else {
                        if (FindNextLeg(returnArray, count + 1, destination, currNode.Connections[c1])) {
                            return true;
                        }
                        else {
                            returnArray[count + 1] = null;
                        }
                    }
                }
            }
            return false;
        }
        public Node[] FindRoute(string start, string end) {
            if (start.Length == 0 || end.Length == 0) {
                throw new ArgumentOutOfRangeException("start or string should not be a zero length");
            }
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
