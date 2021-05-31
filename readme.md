# Panel Tabber

Quick and easy tabbing panels in Unity

![Tab Panel 1](Resources/TabPanel1.png)

![Tab Panel 2](Resources/TabPanel2.png)

## Installation
Follow the steps [Here](https://github.com/FedoraDevStudios/Installation-Unity) to add this package to your Unity project using this package's URL.

## Usage
The easiest way to use this package is with the built-in behaviour component. Create a structure with a similar structure to below. Note you do not have to nest additional Tab Panels, this is only to illustrate that it is possible. Also note, technically you do not need to follow this structure to a T. You can assign any arbitrary button with any arbitrary element.

```
Canvas
└── Tab Panel
|	└── Tabs
|	|	└── Btn Tab 1
|	|	└── Btn Tab 2
|	|	└── Btn Tab 3
|	|	└── Btn Tab 4
|	└── Panels
|	|	└── Panel 1
|	|	└── Panel 2
|	|	└── Panel 3
|	|	└── Tab Panel
|	|	|	└── Tabs
|	|	|	|	└── Btn Tab 1
|	|	|	|	└── Btn Tab 2
|	|	|	|	└── Btn Tab 3
|	|	|	└── Panels
|	|	|	|	└── Panel 1
|	|	|	|	└── Panel 2
|	|	|	|	└── Panel 3
```

Once this structure is in place, add the `TabPanelBehaviour` component to the `Tab Panel` and choose the implementation you would prefer in the drop down. If you use `CategoryTabber`, then simply add `Tabs` as the Tab Parent and `Panels` as the Panel Parent. If you choose `TabToPanelTabber`, then you will have to assign the individual tab buttons and panel objects instead. The index of the tab aligns with the index of the panel.

Now that you have the references assigned, you can use the `Next Tab` and `Previous Tab` to cycle through. Note that the buttons will likely need to have their transitions for `Normal Color` and `Disabled Color` swapped so the active tab looks more prominent. This does come down to the style of your game, though. The functionality of this system is completely agnostic to the style of your game.

## Implementation
As with all of our systems, you can implement your own Tab Panel implementations. The only interface in the system is `ITabPanel` and there are only 4 items to implement. This package includes a few examples out of the box to get you up and running, the simplest of which is `TabToPanelTabber`. This sample uses Buttons as tabs and automatically adds `GoToTab` to the click events on each button.

The 4 items you need to implement are as follows:
```c#
int ActiveTab { get; }
int TabQuantity { get; }
void Initialize();
void GoToTab();
```

### ActiveTab
This simply returns the currently active tab. In the example, I'm running a quick calculation to find the first non-interactable button and returning that index.

### TabQuantity
This just returns the amount of tabs that are present.

### Initialize
This is where any first-time setup is run. With the `TabPanelBehaviour`, this is called during `OnEnable`.

### GoToTab
This is where the magic happens. Given an index, this function disables any visible panels and enables the desired one. It also changes the buttons to their required interactable state.