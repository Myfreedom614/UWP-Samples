//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace UWPCreateCurCPPAPP1;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::UI::Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPage::MainPage()
{
	InitializeComponent();
	Windows::UI::Core::CoreCursorType cursorType = Windows::UI::Core::CoreCursorType::Custom;
	CoreCursor ^* theCursor = new CoreCursor ^ (nullptr);
	*theCursor = ref new CoreCursor(cursorType, 101);
	CoreWindow::GetForCurrentThread()->PointerCursor = *theCursor;
}
