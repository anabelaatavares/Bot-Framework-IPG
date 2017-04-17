﻿using IPGLicenciaturas;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InBytesBot
{
    [LuisModel("4ec615fd-e326-47b9-8096-59b0e4fb20e1", "8ea59e25a8c14a9e9e3e952afeece069")]
    [Serializable]
    public class SimpleLUISDialog : LuisDialog<object>
    {
        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.Attachments = new List<Attachment>();
            List<CardImage> images = new List<CardImage>();
            CardImage ci = new CardImage("http://www.ipg.pt/website/imgs/logotipo_ipg.jpg");
            images.Add(ci);
            CardAction ca = new CardAction()
            {
                Title = "Visitar para mais informações",
                Type = "openUrl",
                Value = "http://www.ipg.pt/website/"
            };
            ThumbnailCard tc = new ThumbnailCard()
            {
                Title = "Precisas de ajuda?!",
                Subtitle = "Acessa ao site para mais infromações",
                Images = images,
                Tap = ca
            };
            reply.Attachments.Add(tc.ToAttachment());
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        public static Licenciaturas cursos = new Licenciaturas();
        [LuisIntent("cursoCount")]
        public async Task GetcursoCount(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Existem neste preciso momento { cursos.GetCursoCount() } cursos.");
            context.Wait(MessageReceived);
        }


        [LuisIntent("cursoGet")]
        public async Task Getcurso(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"No IPG exite: { cursos.GetCursos() } .");
            context.Wait(MessageReceived);
        }


        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Não te consigo ajudar, sê mais específico/a.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Topcurso")]
        public async Task Bestcurso(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ cursos.GetHighestRatedCurso()} é o curso que está melhor classificado no IPG");
            context.Wait(MessageReceived);
        }


        [LuisIntent("TopTreecurso")]
        public async Task Best3curso(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ cursos.GetTopThreeCursos()} ");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Bottomcurso")]
        public async Task Bottomcurso(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"{ cursos.GetLowestRatedCurso()} o curso com pior classificação no IPG");
            context.Wait(MessageReceived);
        }
    }
}