﻿using Core.Objects;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.FrontEnd.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteEditor : Page
    {
        public NoteEditor()
        {

            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainPage.Get.SetNavigationIndex(3);
            if (MainPage.CurrentNote != null)
            {
                EditorTextBox.Text = MainPage.CurrentNote.Content;
                RenderBlock.Text = MainPage.CurrentNote.Content;
                NoteNameTextBox.Text = MainPage.CurrentNote.Name;
                MainPage.CurrentNote = MainPage.CurrentNote;
                MainPage.Get.SetDividerNoteName(MainPage.CurrentNote.Name);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NoteEditorTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            RenderBlock.Text = ((TextBox)sender).Text;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.CurrentNote == null)
            {
                MainPage.CurrentNote = new Note() { Content = EditorTextBox.Text, Name = NoteNameTextBox.Text };
                MainPage.context.Add(MainPage.CurrentNote);
                MainPage.context.SaveChangesAsync();
            }
            else
            {
                MainPage.CurrentNote.Update(EditorTextBox.Text, NoteNameTextBox.Text, MainPage.context);
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ImportPictureButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MarkdownText_OnImageResolving(object sender, ImageResolvingEventArgs e)
        {
            // This is basically the default implementation
            try
            {
                if (e.Url.ToLower().StartsWith("http"))
                {
                    e.Image = new BitmapImage(new Uri(e.Url));
                }
                else
                {
                    e.Image = new BitmapImage(new Uri(e.Url));
                }
            }
            catch (Exception ex)
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }
    }
}
