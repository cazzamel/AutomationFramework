using AutomationFramework.Base;
using TechTalk.SpecFlow;

namespace EAEmployeeTest.Pages
{
    [Binding]
    public class SampleFeatureSteps : BaseStep
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
           
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I click login link")]
        public void ThenIClickLoginLink()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter UserName and Password and click login")]
        public void WhenIEnterUserNameAndPasswordAndClickLogin(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
