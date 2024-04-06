﻿// Copyright (c) Bili Copilot. All rights reserved.

using Bili.Copilot.Models.App.Args;
using Bili.Copilot.Models.App.Other;
using Bili.Copilot.ViewModels;

namespace Bili.Copilot.App.Pages;

/// <summary>
/// 视频播放 MPV 附属页面.
/// </summary>
public sealed partial class VideoMpvPlayerPage : VideoPlayerPageBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VideoMpvPlayerPage"/> class.
    /// </summary>
    public VideoMpvPlayerPage()
    {
        InitializeComponent();
        ViewModel = new VideoPlayerPageViewModel();
        DataContext = ViewModel;
    }

    /// <inheritdoc/>
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is PlayerPageNavigateEventArgs args)
        {
            ViewModel.SetWindow(args.AttachedWindow);

            if (args.Snapshot != null)
            {
                ViewModel.SetSnapshot(args.Snapshot);
            }
            else if (args.Playlist != null)
            {
                ViewModel.SetPlaylist(args.Playlist);
            }
        }
    }

    /// <inheritdoc/>
    protected override async void OnPageUnloaded()
    {
        try
        {
            ViewModel.PlayerDetail.Player?.Dispose();
            await ViewModel.PlayerDetail.ReportViewProgressCommand.ExecuteAsync(default);
            ViewModel?.Dispose();
            ViewModel = null;
        }
        catch (Exception)
        {
        }
    }

    private void OnSectionItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        var item = args.InvokedItem as PlayerSectionHeader;
        if (ViewModel.CurrentSection != item)
        {
            ViewModel.CurrentSection = item;
        }
    }
}
