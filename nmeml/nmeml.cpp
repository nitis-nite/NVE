#include "nmeml.h"

extern "C" {
	void _deleteArray(char* ptr, int size) {
#ifdef ARR_DEL
		delete[size] ptr;
#else
		delete[] ptr;
#endif 

	};
	EXPORT char* _alloc32B() {
		char* c = new char[32];
		return c;
	};
	EXPORT void _unlock32B(char* ptr) {
		_deleteArray(ptr, 32);
	};



	EXPORT char* _alloc128B() {
		char* c = new char[128];
		return c;
	};
	EXPORT void _unlock128B(char* ptr) {
		_deleteArray(ptr, 128);
	};



	EXPORT char* _alloc256B() {
		char* c = new char[256];
		return c;
	};
	EXPORT void _unlock256B(char* ptr) {
		_deleteArray(ptr, 256);
	};



	EXPORT char* _alloc512B() {
		char* c = new char[512];
		return c;
	};
	EXPORT void _unlock512B(char* ptr) {
		_deleteArray(ptr, 512);
	};



	EXPORT char* _alloc1KB() {
		char* c = new char[1024];
		return c;
	};
	EXPORT void _unlock1KB(char* ptr) {
		_deleteArray(ptr, 1024);
	};
};