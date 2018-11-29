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
namespace FunctionalTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Registration", Description="\tIn order to use CSAA\r\n\tAs a unregistered user\r\n\tI can register", SourceFile="Features\\Registration.feature", SourceLine=0)]
    public partial class RegistrationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Registration.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Registration", "\tIn order to use CSAA\r\n\tAs a unregistered user\r\n\tI can register", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 8
 testRunner.Then("I am on the \"Login\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.When("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Register", SourceLine=11)]
        public virtual void Register()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register", null, ((string[])(null)));
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
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
#line 14
 testRunner.When("I enter the following:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Password",
                        "password"});
            table2.AddRow(new string[] {
                        "ConfirmPassword",
                        "password"});
#line 20
 testRunner.And("I enter the following passwords:", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "ProductOwner",
                        "Yes"});
            table3.AddRow(new string[] {
                        "ScrumMaster",
                        "Yes"});
            table3.AddRow(new string[] {
                        "Developer",
                        "Yes"});
#line 25
 testRunner.And("I check the following:", ((string)(null)), table3, "And ");
#line 31
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
                        "testuser@localhost.com"});
            table4.AddRow(new string[] {
                        "Password",
                        "password"});
            table4.AddRow(new string[] {
                        "ProductOwner",
                        "Yes"});
            table4.AddRow(new string[] {
                        "ScrumMaster",
                        "Yes"});
            table4.AddRow(new string[] {
                        "Developer",
                        "Yes"});
#line 33
 testRunner.Then("the a user account is created with the following details:", ((string)(null)), table4, "Then ");
#line 42
 testRunner.Then("I am on the \"Login\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Register - Failed", SourceLine=43)]
        public virtual void Register_Failed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register - Failed", null, ((string[])(null)));
#line 44
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "Name",
                        "Test User"});
            table5.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
            table5.AddRow(new string[] {
                        "Password",
                        "password"});
            table5.AddRow(new string[] {
                        "ProductOwner",
                        "Yes"});
            table5.AddRow(new string[] {
                        "ScrumMaster",
                        "Yes"});
            table5.AddRow(new string[] {
                        "Developer",
                        "Yes"});
#line 46
 testRunner.Given("the following user account exists:", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table6.AddRow(new string[] {
                        "Surname",
                        "User"});
            table6.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 55
 testRunner.When("I enter the following:", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table7.AddRow(new string[] {
                        "Password",
                        "password"});
            table7.AddRow(new string[] {
                        "ConfirmPassword",
                        "password"});
#line 61
 testRunner.And("I enter the following passwords:", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table8.AddRow(new string[] {
                        "ProductOwner",
                        "Yes"});
            table8.AddRow(new string[] {
                        "ScrumMaster",
                        "Yes"});
            table8.AddRow(new string[] {
                        "Developer",
                        "Yes"});
#line 66
 testRunner.And("I check the following:", ((string)(null)), table8, "And ");
#line 72
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.Then("I am on the \"Registration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table9.AddRow(new string[] {
                        "InvalidFields",
                        "Name Test User is already taken. Email \'testuser@localhost.com\' is already taken." +
                            ""});
#line 76
 testRunner.And("the following errors appear:", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - FirstName", SourceLine=79)]
        public virtual void RequiredFieldsValidation_FirstName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - FirstName", null, ((string[])(null)));
#line 80
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table10.AddRow(new string[] {
                        "FirstName",
                        ""});
            table10.AddRow(new string[] {
                        "Surname",
                        "User"});
            table10.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 82
 testRunner.When("I enter the following:", ((string)(null)), table10, "When ");
#line 88
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table11.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 92
 testRunner.And("the following errors appear:", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - Surname", SourceLine=95)]
        public virtual void RequiredFieldsValidation_Surname()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - Surname", null, ((string[])(null)));
#line 96
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table12.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table12.AddRow(new string[] {
                        "Surname",
                        ""});
            table12.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 98
 testRunner.When("I enter the following:", ((string)(null)), table12, "When ");
#line 104
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table13.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 108
 testRunner.And("the following errors appear:", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Required Fields Validation - Email", SourceLine=111)]
        public virtual void RequiredFieldsValidation_Email()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Required Fields Validation - Email", null, ((string[])(null)));
#line 112
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table14.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table14.AddRow(new string[] {
                        "Surname",
                        "User"});
            table14.AddRow(new string[] {
                        "Email",
                        ""});
#line 114
 testRunner.When("I enter the following:", ((string)(null)), table14, "When ");
#line 120
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table15.AddRow(new string[] {
                        "InvalidFields",
                        "Please populate all fields."});
#line 124
 testRunner.And("the following errors appear:", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Email Validation", SourceLine=127)]
        public virtual void EmailValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email Validation", null, ((string[])(null)));
#line 128
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
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
                        "testuser@localhost"});
#line 130
 testRunner.When("I enter the following:", ((string)(null)), table16, "When ");
#line 136
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table17.AddRow(new string[] {
                        "InvalidFields",
                        "Invalid email."});
#line 140
 testRunner.And("the following errors appear:", ((string)(null)), table17, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password Validation - empty", SourceLine=143)]
        public virtual void PasswordValidation_Empty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password Validation - empty", null, ((string[])(null)));
#line 144
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table18.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table18.AddRow(new string[] {
                        "Surname",
                        "User"});
            table18.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 146
 testRunner.When("I enter the following:", ((string)(null)), table18, "When ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table19.AddRow(new string[] {
                        "Password",
                        "password"});
            table19.AddRow(new string[] {
                        "ConfirmPassword",
                        ""});
#line 152
 testRunner.And("I enter the following passwords:", ((string)(null)), table19, "And ");
#line 157
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table20.AddRow(new string[] {
                        "InvalidPassword",
                        "Passwords do not match."});
#line 161
 testRunner.And("the following errors appear:", ((string)(null)), table20, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Password Validation - mistmatch", SourceLine=164)]
        public virtual void PasswordValidation_Mistmatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password Validation - mistmatch", null, ((string[])(null)));
#line 165
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table21.AddRow(new string[] {
                        "FirstName",
                        "Test"});
            table21.AddRow(new string[] {
                        "Surname",
                        "User"});
            table21.AddRow(new string[] {
                        "Email",
                        "testuser@localhost.com"});
#line 167
 testRunner.When("I enter the following:", ((string)(null)), table21, "When ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table22.AddRow(new string[] {
                        "Password",
                        "password"});
            table22.AddRow(new string[] {
                        "ConfirmPassword",
                        "Pa$$w0rd"});
#line 173
 testRunner.And("I enter the following passwords:", ((string)(null)), table22, "And ");
#line 178
 testRunner.And("I click \"Register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.Then("the no user accounts are created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table23.AddRow(new string[] {
                        "InvalidPassword",
                        "Passwords do not match."});
#line 182
 testRunner.And("the following errors appear:", ((string)(null)), table23, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Login Button", SourceLine=185)]
        public virtual void LoginButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login Button", null, ((string[])(null)));
#line 186
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
this.FeatureBackground();
#line 188
 testRunner.When("I click \"Login\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.Then("I am on the \"Login\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
