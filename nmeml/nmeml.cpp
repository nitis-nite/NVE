#include "nmeml.h"

extern "C" {
	nmenl char* _alloc32B() {
		char* c = new char[32];
		return c;
	};
	nmenl void _unlock32B(char* ptr) {
		delete[32] ptr;
	};



	nmenl char* _alloc128B() {
		char* c = new char[128];
		return c;
	};
	nmenl void _unlock128B(char* ptr) {
		delete[128] ptr;
	};



	nmenl char* _alloc256B() {
		char* c = new char[256];
		return c;
	};
	nmenl void _unlock256B(char* ptr) {
		delete[256] ptr;
	};



	nmenl char* _alloc512B() {
		char* c = new char[512];
		return c;
	};
	nmenl void _unlock512B(char* ptr) {
		delete[512] ptr;
	};



	nmenl char* _alloc1KB() {
		char* c = new char[1024];
		return c;
	};
	nmenl void _unlock1KB(char* ptr) {
		delete[1024] ptr;
	};
};