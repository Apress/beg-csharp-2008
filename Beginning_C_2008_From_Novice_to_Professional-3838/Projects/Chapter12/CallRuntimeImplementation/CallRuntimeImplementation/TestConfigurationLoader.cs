using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Definitions;

namespace CallRuntimeImplementation {
    static class TestConfigurationLoader {
        public static void TestCrossReference() {
            ConfigurationLoader.Instance.Load();
            Console.WriteLine(ConfigurationLoader.Instance.ToString());

            IDefinition definition = ConfigurationLoader.Instance.Instantiate<IDefinition>("Impl1");
            Console.WriteLine(definition.TranslateWord("hello"));
            definition = ConfigurationLoader.Instance.InstantiateStrongType<IDefinition>("Impl2");
            Console.WriteLine(definition.TranslateWord("hello"));
        }
        public static void TestCustomLoader() {
            ConfigurationLoader.Instance.LoadCustomSection();
            Console.WriteLine(ConfigurationLoader.Instance.ToString());

            IDefinition definition = ConfigurationLoader.Instance.Instantiate<IDefinition>("Impl1");
            Console.WriteLine(definition.TranslateWord("hello"));
        }
        public static void RunAll() {
            //TestCrossReference();
            TestCustomLoader();
        }
    }
}
