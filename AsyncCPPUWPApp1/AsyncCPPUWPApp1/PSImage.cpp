#include "pch.h"
#include <pplawait.h>
#include "PSImage.h"

using namespace PSImageLibrary;

using namespace Platform;
using namespace Concurrency;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Storage;
using namespace Windows::Storage::Streams;
using namespace Windows::Graphics::Imaging;

PSImage::PSImage() {
	transform = ref new BitmapTransform();
}

PSImage::~PSImage() { }

IAsyncAction ^ PSImage::open(StorageFile^ file)
{
	return create_async([this, file]()
	{
		//return testTask();
		return create_async([this, file]() -> task<void> {
			stream = co_await file->OpenAsync(FileAccessMode::Read);
			co_await _decode(stream);
		});
	});
}

IAsyncAction ^ PSImage::_decode(IRandomAccessStream^ stream) {
	return create_async([this, stream] {
		return create_async([this, stream]() -> task<void> {
			decoder = co_await BitmapDecoder::CreateAsync(stream);
		});
	});
}

Concurrency::task<void> PSImage::testTask() {
	return create_task([]() {
		OutputDebugString(L"Test");
	});
}