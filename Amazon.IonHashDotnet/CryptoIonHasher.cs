﻿/*
 * Copyright 2020 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

namespace Amazon.IonHashDotnet
{
    using System;
    using System.Security.Cryptography;

    internal class CryptoIonHasher : IIonHasher
    {
        private readonly HashAlgorithm hashAlgorithm;

        internal CryptoIonHasher(string algorithm)
        {
            this.hashAlgorithm = HashAlgorithm.Create(algorithm);

            if (this.hashAlgorithm == null)
            {
                throw new ArgumentException("Invalid Algorithm Specified");
            }
        }

        public virtual void Update(byte[] bytes)
        {
            this.hashAlgorithm.TransformBlock(bytes, 0, bytes.Length, bytes, 0);
        }

        public virtual byte[] Digest()
        {
            this.hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
            return this.hashAlgorithm.Hash;
        }
    }
}
