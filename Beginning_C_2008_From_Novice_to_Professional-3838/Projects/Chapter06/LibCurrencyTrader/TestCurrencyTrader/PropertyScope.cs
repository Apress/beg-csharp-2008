class PropertyScopeExample {
    int _value;

    public int Value {
        protected set {
            _value = value;
        }
        get {
            return _value;
        }
    }
}