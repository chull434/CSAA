﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FunctionalTests.Features.Client
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("AccountFeature", Description="\tIn order to use CSAA\r\n\tAs a unregistered user\r\n\tI can register", SourceFile="Features\\Client\\AccountFeature.feature", SourceLine=0)]
    public partial class AccountFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountFeature.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccountFeature", "\tIn order to use CSAA\r\n\tAs a unregistered user\r\n\tI can register", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Register", SourceLine=5)]
        public virtual void Register()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register", null, ((string[])(null)));
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table1.AddRow(new string[] {
                        "Surname",
                        "User"});
            table1.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 10
 testRunner.When("I enter the following:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Input",
                        "password"});
            table2.AddRow(new string[] {
                        "Input_Confirm",
                        "password"});
#line 16
 testRunner.And("I enter the following passwords:", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "ProductOwner",
                        "Yes"});
            table3.AddRow(new string[] {
                        "ScumMaster",
                        "Yes"});
            table3.AddRow(new string[] {
                        "Developer",
                        "Yes"});
#line 21
 testRunner.And("I check the following:", ((string)(null)), table3, "And ");
#line 27
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Name",
                        "Test User"});
            table4.AddRow(new string[] {
                        "Email",
                        "testuser@localhost"});
            table4.AddRow(new string[] {
                        "Password",
                        "password"});
            table4.AddRow(new string[] {
                        "product_owner",
                        "Yes"});
            table4.AddRow(new string[] {
                        "scrum_master",
                        "Yes"});
            table4.AddRow(new string[] {
                        "developer",
                        "Yes"});
#line 29
 testRunner.Then("the a user account is created with the following details:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - FirstName", SourceLine=37)]
        public virtual void RequiredFieldsValidation_FirstName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - FirstName", null, ((string[])(null)));
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 40
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "FirstName",
                        ""});
            table5.AddRow(new string[] {
                        "Surname",
                        "User"});
            table5.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 42
 testRunner.When("I enter the following:", ((string)(null)), table5, "When ");
#line 48
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 52
 testRunner.And("the following errors appear:", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - Surname", SourceLine=55)]
        public virtual void RequiredFieldsValidation_Surname()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - Surname", null, ((string[])(null)));
#line 56
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 58
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table7.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table7.AddRow(new string[] {
                        "Surname",
                        ""});
            table7.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 60
 testRunner.When("I enter the following:", ((string)(null)), table7, "When ");
#line 66
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table8.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 70
 testRunner.And("the following errors appear:", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - Email", SourceLine=73)]
        public virtual void RequiredFieldsValidation_Email()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - Email", null, ((string[])(null)));
#line 74
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 76
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table9.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table9.AddRow(new string[] {
                        "Surname",
                        "User"});
            table9.AddRow(new string[] {
                        "Email",
                        ""});
#line 78
 testRunner.When("I enter the following:", ((string)(null)), table9, "When ");
#line 84
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table10.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 88
 testRunner.And("the following errors appear:", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Email Validation", SourceLine=91)]
        public virtual void EmailValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email Validation", null, ((string[])(null)));
#line 92
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 94
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table11.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table11.AddRow(new string[] {
                        "Surname",
                        "User"});
            table11.AddRow(new string[] {
                        "Email",
                        "testuser@localhost"});
#line 96
 testRunner.When("I enter the following:", ((string)(null)), table11, "When ");
#line 102
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table12.AddRow(new string[] {
                        "InvalidFields",
                        "Invalid email."});
#line 106
 testRunner.And("the following errors appear:", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password Validation - empty", SourceLine=109)]
        public virtual void PasswordValidation_Empty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password Validation - empty", null, ((string[])(null)));
#line 110
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 112
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table13.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table13.AddRow(new string[] {
                        "Surname",
                        "User"});
            table13.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 114
 testRunner.When("I enter the following:", ((string)(null)), table13, "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table14.AddRow(new string[] {
                        "Input",
                        "password"});
            table14.AddRow(new string[] {
                        "Input_Confirm",
                        ""});
#line 120
 testRunner.And("I enter the following passwords:", ((string)(null)), table14, "And ");
#line 125
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table15.AddRow(new string[] {
                        "InvalidPassword",
                        "Passwords do not match."});
#line 129
 testRunner.And("the following errors appear:", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password Validation - mistmatch", SourceLine=132)]
        public virtual void PasswordValidation_Mistmatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password Validation - mistmatch", null, ((string[])(null)));
#line 133
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 135
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table16.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table16.AddRow(new string[] {
                        "Surname",
                        "User"});
            table16.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 137
 testRunner.When("I enter the following:", ((string)(null)), table16, "When ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table17.AddRow(new string[] {
                        "Input",
                        "password"});
            table17.AddRow(new string[] {
                        "Input_Confirm",
                        "Pa$$w0rd"});
#line 143
 testRunner.And("I enter the following passwords:", ((string)(null)), table17, "And ");
#line 148
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table18.AddRow(new string[] {
                        "InvalidPassword",
                        "Passwords do not match."});
#line 152
 testRunner.And("the following errors appear:", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Login", SourceLine=25)]
        public virtual void Login()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login", null, ((string[])(null)));
#line 26
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Name",
                        "Test User"});
            table3.AddRow(new string[] {
                        "Email",
                        "testuser@localhost"});
            table3.AddRow(new string[] {
                        "Password",
                        "password"});
            table3.AddRow(new string[] {
                        "product_owner",
                        "Yes"});
            table3.AddRow(new string[] {
                        "scrum_master",
                        "Yes"});
            table3.AddRow(new string[] {
                        "developer",
                        "Yes"});
#line 28
 testRunner.Given("a user exists:", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Email",
                        "testuser@localhost"});
            table4.AddRow(new string[] {
                        "Password",
                        "password"});
#line 37
 testRunner.When("I login with the following details:", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "Email",
                        "testuser@localhost"});
#line 42
 testRunner.Then("the user is logged in:", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
