#include "nmeml.h"

extern "C" {
	EXPORT char* _alloc32B() {
		char* c = new char[32];
		return c;
	};
	EXPORT void _unlock32B(char* ptr) {
		delete[32] ptr;
	};



	EXPORT char* _alloc128B() {
		char* c = new char[128];
		return c;
	};
	EXPORT void _unlock128B(char* ptr) {
		delete[128] ptr;
	};



	EXPORT char* _alloc256B() {
		char* c = new char[256];
		return c;
	};
	EXPORT void _unlock256B(char* ptr) {
		delete[256] ptr;
	};



	EXPORT char* _alloc512B() {
		char* c = new char[512];
		return c;
	};
	EXPORT void _unlock512B(char* ptr) {
		delete[512] ptr;
	};



	EXPORT char* _alloc1KB() {
		char* c = new char[1024];
		return c;
	};
	EXPORT void _unlock1KB(char* ptr) {
		delete[1024] ptr;
	};
};