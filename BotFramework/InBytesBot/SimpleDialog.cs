using IPGLicenciaturas;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace InBytesBot
{
    [Serializable]
    public class SimpleDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReceivedAsync);
        }

        private async Task ActivityReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            Licenciaturas cursos = new Licenciaturas();
            if (activity.Text.Contains("Quantas equipas"))
            {

                await context.PostAsync($"There are { cursos.GetCursoCount() } teams.");
            }
            else if (activity.Text.StartsWith("who") || activity.Text.StartsWith("which team"))
            { 
                if (activity.Text.Contains("best") || activity.Text.Contains("highest") || activity.Text.Contains("greatest"))
                {
                    await context.PostAsync($"The highest ranked team is { cursos.GetHighestRatedCurso() }");
                }
                else if (activity.Text.Contains("worst") || activity.Text.Contains("lowest"))
                {
                    await context.PostAsync($"The lowest ranked team is { cursos.GetLowestRatedCurso() }");
                }
            }
            else
            {
                await context.PostAsync("Sorry but my responses are limited. Please ask the right questsions.");
            }
            context.Wait(ActivityReceivedAsync);
        }
    }
}
