﻿// Copyright (c) 2007-2011 SlimDX Group
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SlimDX.Generator
{
	class TypeModel
	{
		static TypeModel()
		{
			VoidModel = CreateReferenceModel("void", typeof(void));
		}

		public TypeModel(string name, TypeModelKind kind, Guid guid, TypeModel baseType, Type managedType)
		{
			Name = name;
			Kind = kind;
			Guid = guid;
			BaseType = baseType;
			ManagedType = managedType;
		}

		public string Name
		{
			get;
			private set;
		}

		public TypeModelKind Kind
		{
			get;
			private set;
		}

		public Guid Guid
		{
			get;
			private set;
		}

		public TypeModel BaseType
		{
			get;
			private set;
		}

		public Type ManagedType
		{
			get;
			private set;
		}

		public ReadOnlyCollection<MethodModel> Methods
		{
			get
			{
				return methods.AsReadOnly();
			}
		}

		public static TypeModel VoidModel
		{
			get;
			private set;
		}

		public void AddMethod(MethodModel method)
		{
			methods.Add(method);
		}

		public override string ToString()
		{
			return Name.ToString();
		}

		public static TypeModel CreateInterfaceModel(string name, Guid guid, TypeModel baseType)
		{
			return new TypeModel(name, TypeModelKind.Interface, guid, baseType, null);
		}

		public static TypeModel CreateReferenceModel(string name, Type managedType)
		{
			return new TypeModel(name, TypeModelKind.Reference, Guid.Empty, null, managedType);
		}

		List<MethodModel> methods = new List<MethodModel>();
	}
}
