using Microsoft.AspNetCore.Components;
using;

namespace BlazorTest.Pages
{
    public partial class Index
    {
        private EventCallback<int> OnButtonClick { get; set; }

        private string Value { get; set; }

        public Guid? Reset { get; set; }

        public Dictionary<int, ButtonDefinition> Buttons { get; set; }

        public class ButtonDefinition
        {
            public string Caption { get; set; }
            public string Icon { get; set; }
        }

        protected override void OnInitialized()
        {
            int i = 3;
            Buttons = new();

            for (int j = 1; j <= i; j++)
            {
                Buttons.Add(j, new ButtonDefinition { Caption = $"T{j}", Icon = $"icon{j}.png" });
            }

            elapsedTimeInSeconds = 0;
            timer = new Timer(UpdateElapsedTime, null, 0, 1000);
        }

        public List<int> ClickedButtons = new();
        public int Message { get; set; }
        private async Task Clicked(int Id)
        {
            ClickedButtons.Add(Id);
            await OnButtonClick.InvokeAsync(Id);
        }

        private string otherValue { get; set; }
        public void MyMethod()
        {
            otherValue = Value;
        }

        Guid initializeGuid = Guid.NewGuid();

        public void clickedResetButton()
        {
            Guid newGuid = Guid.NewGuid();
            if (newGuid != initializeGuid)
            {
                Value = "";
                elapsedTimeInSeconds = 0;
                ClickedButtons.Clear();
            }
        }

        private Timer timer;
        private int elapsedTimeInSeconds;
        private string time;

        private void StopTimer()
        {
            timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void UpdateElapsedTime(object state)
        {
            elapsedTimeInSeconds++;
            time = $"Czas pracy (sekundy): {elapsedTimeInSeconds}";
            InvokeAsync(StateHasChanged);
        }
    }
}