#pragma once

template <typename Type>
class DynArray
{
	Type* array;
	unsigned int Size, Capacity;
public:
	/////////////////////////////////////////////////////////////////////////////
	// Function :	Constructor
	// Notes : Constructs an empty array (Size 0 Capacity 0)
	/////////////////////////////////////////////////////////////////////////////
	DynArray()
	{
		Size = Capacity = 0;
		array = nullptr;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	Destructor
	// Notes : cleans up any dynamic memory
	/////////////////////////////////////////////////////////////////////////////
	~DynArray()
	{
		delete[] array;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	Copy Constructor
	/////////////////////////////////////////////////////////////////////////////
	DynArray(const DynArray<Type>& that)
	{
		array = nullptr;
		//Size = Capacity = 0;
		*this = that;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	Assignment Operator
	/////////////////////////////////////////////////////////////////////////////
	DynArray<Type>& operator=(const DynArray<Type>& that)
	{
		if (this != &that)
		{
			// Clear the original array
			clear();
			this->Size = that.Size;
			this->Capacity = that.Capacity;

			array = new Type[Capacity];
			for (unsigned int i = 0; i < Size; ++i)
				this->array[i] = that.array[i];
		}
		return *this;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function : operator[]
	// Parameters : index - the index to access
	// Return : Type & - returns the array element at [index]
	// Notes : performs no error checking. user should ensure index is 
	//		valid with the size() method
	/////////////////////////////////////////////////////////////////////////////
	Type& operator[](const unsigned int index)
	{
		return array[index];
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function : operator[]
	// Parameters : index - the index to access
	// Return : const Type & - returns the array element at [index]
	// Notes : performs no error checking. user should ensure index is 
	//		valid with the size() method
	/////////////////////////////////////////////////////////////////////////////
	const Type& operator[](const unsigned int index) const
	{
		return array[index];
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	size
	// Returns : int - returns the number of items being stored
	// Notes : this function returns the number of items being stored, 
	/////////////////////////////////////////////////////////////////////////////
	unsigned int size() const
	{
		return Size;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function : capacity
	// Returns : int - returns the number of items the array can store before 
	//		the next resize
	// Notes : this function returns the number of items the array can store, 
	//		not the number of bytes
	/////////////////////////////////////////////////////////////////////////////
	unsigned int capacity() const
	{
		return Capacity;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	clear
	// Notes : cleans up any dynamic memory and resets size and capacity to 0
	/////////////////////////////////////////////////////////////////////////////
	void clear()
	{
		delete[] array;
		array = nullptr;
		Size = Capacity = 0;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function : append
	// Parameters : item - the item to be appended to the next open spot
	// Notes : this function will append the item to the next open spot. if 
	//		no room exists, the array's capacity will be doubled and then 
	//		the item will be added
	/////////////////////////////////////////////////////////////////////////////
	void append(const Type& item)
	{
		// if the array is full, expand it...
		if (Size == Capacity)
		{
			//adjust the capacity 
			if (0 == Capacity) // if you have a constant value, put it on the left.
				Capacity = 1;
			else
				Capacity *= 2;
			// make a temp array and copy the old one.
			Type* temp = new Type[Capacity];
			for (unsigned int i = 0; i < Size; ++i)
			{
				temp[i] = array[i];
			}
			//delete the old array
			delete[] array;
			//point the class to the new array
			array = temp;
		}

		//add a new item at the next index and increment our size variable
		array[Size++] = item;
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function : reserve
	// Parameters : newCap - the new capacity
	// Notes : 	- default parameter - reserve more space in the array, based on //		the expansion rate (100%, 1 minimum).
	//		- non-default parameter, expand to the specified capacity
	//		- if newCap is LESS than the current capacity, do nothing. 
	//		This function should NOT make the array smaller.
	/////////////////////////////////////////////////////////////////////////////
	void reserve(const unsigned int& newCap = 0)
	{
		if (newCap == 0)
		{
			Capacity = (Capacity == 0) ? 1 : Capacity * 2;
		/*	if (0 == Capacity)
			{
				Capacity = 1;
			}
			else
			{
				Capacity *= 2;
			}*/
		}
		else if (newCap > Capacity)
			Capacity = newCap;
		else
			return;

		// make a temp array and copy the old one.
		Type* temp = new Type[Capacity];

		for (unsigned int i = 0; i < Size; ++i)
			temp[i] = array[i];
		//delete the old array
		delete[] array;
		//point the class to the new array
		array = temp;

	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	insert
	// Parameters : val - the value to insert
	//		   index - the index to insert at
	// Notes : if the array is full, this function should expand the array at 
	//		the default expansion rate (double the capacity, 1 minimum)
	/////////////////////////////////////////////////////////////////////////////
	void insert(const Type val, const unsigned int index)
	{
		if (index == Size)
			append(val);
		else if (index > Size)
		{
			return;
		}
		else if (index < Size)
		{
			// if the array is full, expand it...
			if (Size == Capacity)
			{
				//adjust the capacity 
				if (0 == Capacity) // if you have a constant value, put it on the left.
					Capacity = 1;
				else
					Capacity *= 2;
				// make a temp array and copy the old one.
				Type* temp = new Type[Capacity];
				for (unsigned int i = 0; i < Size; ++i)
				{
					temp[i] = array[i];
				}
				//delete the old array
				delete[] array;
				//point the class to the new array
				array = temp;
			}

			//
			for (unsigned int i = Size; i > index; i--)
			{
				array[i] = array[i - 1];
			}
			array[index] = val;
			Size++;
		}
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function :	insert
	// Parameters : val - the items to insert
	//		   n - the number of items to insert
	//		   index - the index to insert at
	// Notes : if the array is full, this function should expand the array at 
	//		the default expansion rate (double the capacity, 1 minimum) 
	//		before inserting
	/////////////////////////////////////////////////////////////////////////////
	void insert(const Type* val, const unsigned int n, const unsigned int index)
	{
		for (unsigned int i = n; i > 0; i--)
		{
			insert(val[i - 1], index);
		}
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function :	remove
	// Parameters : index - the index to remove from
	// Notes : this function removes one item from the specified index
	/////////////////////////////////////////////////////////////////////////////
	void remove(const unsigned int index)
	{
		if (index >= Size)
		{
			return;
		}
		else if (index < Size)
		{
			for (unsigned int i = index; i < Size; i++)
			{
				array[i] = array[i + 1];
			}
			if (Size != 0)
			{
				Size--;
			}
		}
	}

	/////////////////////////////////////////////////////////////////////////////
	// Function :	remove
	// Parameters : index - the index to remove from
	//		   n - the number of items to remove
	// Notes : this function removes multiple items from the specified index
	/////////////////////////////////////////////////////////////////////////////
	void remove(const unsigned int index, const unsigned int n)
	{
		//for (unsigned int j = 0; j < n; j++)
		//{
		//	remove(index);
		//}
		if (n > Size - index || // User put in too many things to remove. (remomve 100 things from array of 2, start at index 0.)
			index >= Size) //Don't have to remove anything.
			return;
		else if (index < Size)
		{
			for (unsigned int i = index; i < Size; i++)
			{
				array[i] = array[i + n];
			}
			Size -= n;
		}
	}

};

