﻿// Copyright (c) Bili Copilot. All rights reserved.

using BiliCopilot.UI.ViewModels.View;
using Richasy.WinUIKernel.Share.Base;

namespace BiliCopilot.UI.Controls.LivePartition;

/// <summary>
/// 直播分区页面控件基类.
/// </summary>
public abstract class LivePartitionPageControlBase : LayoutUserControlBase<LivePartitionPageViewModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LivePartitionPageControlBase"/> class.
    /// </summary>
    protected LivePartitionPageControlBase() => ViewModel = this.Get<LivePartitionPageViewModel>();
}
