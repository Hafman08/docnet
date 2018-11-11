﻿using System;
using Docnet.Core.Bindings;
using Docnet.Core.Editors;
using Docnet.Core.Readers;

namespace Docnet.Core
{
    public sealed class DocLib : IDocLib
    {
        private static readonly object Lock = new object();

        private static DocLib _instance;

        private readonly IDocEditor _editor;

        private DocLib()
        {
            fpdf_view.FPDF_InitLibrary();

            _editor = new DocEditor();
        }

        public static DocLib Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DocLib();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <inheritdoc />
        public IDocReader GetDocReader(string filePath, int dimOne, int dimTwo)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IDocReader GetDocReader(string filePath, string password, int dimOne, int dimTwo)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] Merge(string fileOne, string fileTwo)
        {
            return _editor.Merge(fileOne, fileTwo);
        }

        /// <inheritdoc />
        public byte[] Split(string filePath, int pageFromIndex, int pageToIndex)
        {
            return _editor.Split(filePath, pageFromIndex, pageToIndex);
        }

        /// <inheritdoc />
        public byte[] Unlock(string filePath, string password)
        {
            return _editor.Unlock(filePath, password);
        }

        public void Dispose()
        {
            fpdf_view.FPDF_DestroyLibrary();

            _instance = null;
        }
    }
}
