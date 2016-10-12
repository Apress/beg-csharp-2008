using System;
using System.Text;

namespace Devspace.Trader.Common.Tracer {
    public interface IToStringFormat {
        string FormatBuffer(string input);
    }
    public class FormatToSpaces : IToStringFormat {
        string _inputBuffer;
        private int _spaceCounter;
        bool _needSpaces;
        private StringBuilder _builder = new StringBuilder();
        
        public FormatToSpaces() {
        }
        private void GenerateSpaces() {
            for (int c1 = 0; c1 < _spaceCounter; c1 ++) {
                _builder.Append("   ");
            }
        }
        public string FormatBuffer(string inputBuffer) {
            _inputBuffer = inputBuffer;
            _needSpaces = false;
            foreach (char character in _inputBuffer) {
                switch (character) {
                    case '{':
                        _spaceCounter ++;
                        _needSpaces = true;
                        break;
                    case '}':
                        _spaceCounter --;
                        _needSpaces = true;
                        break;
                    default:
                        if (_needSpaces) {
                            _builder.Append('\n');
                            GenerateSpaces();
                            _needSpaces = false;
                        }
                        _builder.Append(character);
                        break;
                }
            }
            return _builder.ToString();
        }
    }
    public class ToStringFormatState {
        private class DefaultFormatter : IToStringFormat {
            public String FormatBuffer(String input) {
                return input;
            }
        }
        private static IToStringFormat _defaultFormat = new DefaultFormatter();
        private static IToStringFormat _spacesFormat = new FormatToSpaces();
        private static IToStringFormat _defaultState = _defaultFormat;
        public static IToStringFormat DefaultFormat {
            get {
                return _defaultState;
            }
        }
        public static void ToggleToDefault() {
            _defaultState = _defaultFormat;
        }
        public static void ToggleToSpaces() {
            _defaultState = _spacesFormat;
        }
    }
    
    public delegate void ToStringTracerDelegate( ToStringTracer instance);
    
    public class ToStringTracer {
        private string _buffer;
        
        public ToStringTracer() {
        }
        public ToStringTracer Start(string name) {
            _buffer += "{Type: " + name + "";
            return this;
        }
        public ToStringTracer Start( Object obj ) {
            Start( obj.GetType().FullName );
            return this;
        }
        public string End() {
            _buffer += "}";
            return _buffer;
        }
        public ToStringTracer StartArray( string buffer ) {
            _buffer += "{Array " + buffer;
            return this;
        }
        public ToStringTracer EndArray() {
            _buffer += "}";
            return this;
        }
        
        public ToStringTracer Variable(string identifier, int value) {
            _buffer +=  "{Variable: " + identifier + " (" + value + ")}";
            return this;
        }
        public ToStringTracer Variable(string identifier, ulong value) {
            _buffer +=  "{Variable: " + identifier + " (" + value + ")}";
            return this;
        }
        public ToStringTracer Variable(string identifier, string value) {
            _buffer +=  "{Variable: " + identifier + " (" + value + ")}";
            return this;
        }
        public ToStringTracer Variable(string identifier, double[] values) {
            _buffer +=  "{Variable: " + identifier;
            for( int c1 = 0; c1 < values.Length; c1 ++) {
                _buffer += " (Index " + c1 + " " + values[ c1] + ")";
            }
            _buffer += "}";
            return this;
        }
        public ToStringTracer Variable( string identifier, bool value ) {
            if( value ) {
                _buffer += "{Variable: " + identifier + " (true)}";
            }
            else {
                _buffer += "{Variable: " + identifier + " (false)}";
            }
            return this;
        }
        
        public ToStringTracer Base(string value) {
            _buffer += "{Base " + value + "}";
            return this;
        }
        public ToStringTracer Embedded(string value) {
            _buffer += "{" + value + "}";
            return this;
        }
        public ToStringTracer Delegated( ToStringTracerDelegate delegated) {
            delegated( this);
            return this;
        }
    }
}

