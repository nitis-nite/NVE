#include "nmeml.h"

extern "C" {
	void _deleteArray(char* ptr, int size) {
#ifdef ARR_DEL
		delete[size] ptr;
#else
		delete[] ptr;
#endif 

	};
	EXPORT char* _alloc1B() {
		char* c = new char;
		return c;
	};
	EXPORT void _unlock1B(char* ptr) {
		delete ptr;
	};

	EXPORT char* _alloc2B() {
		char* c = new char[2];
		return c;
	};
	EXPORT void _unlock2B(char* ptr) {
		_deleteArray(ptr, 2);
	};

	EXPORT char* _alloc4B() {
		char* c = new char[4];
		return c;
	};
	EXPORT void _unlock4B(char* ptr) {
		_deleteArray(ptr, 4);
	};

	EXPORT char* _alloc8B() {
		char* c = new char[8];
		return c;
	};
	EXPORT void _unlock8B(char* ptr) {
		_deleteArray(ptr, 8);
	};
	EXPORT char* _alloc16B() {
		char* c = new char[16];
		return c;
	};
	EXPORT void _unlock16B(char* ptr) {
		_deleteArray(ptr, 16);
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

	EXPORT char* _alloc(int size) {
		char* c = new char[size];
		return c;
	};
	EXPORT void _unlock(char* ptr) {
		delete ptr;
	};
};