#pragma once
#include "pch.h"

namespace PSImageLibrary {
	public ref class PSImage sealed {

	public:
		PSImage();
		virtual ~PSImage();
		Windows::Foundation::IAsyncAction^ open(Windows::Storage::StorageFile^ file);

	private:
		Windows::Storage::Streams::IRandomAccessStream^ stream;
		Windows::Graphics::Imaging::BitmapDecoder^ decoder;
		Windows::Graphics::Imaging::PixelDataProvider^ provider;
		Windows::Graphics::Imaging::BitmapTransform^ transform;
		Windows::Foundation::IAsyncAction^ _decode(Windows::Storage::Streams::IRandomAccessStream^);
		Concurrency::task<void> testTask();
	};
}

