﻿namespace System;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class TreeBase<T> : ITree<T> where T : NodeBase<T> {

    // Root
    protected T? Root { get; private set; }
    // Root
    T? ITree<T>.Root => Root;

    // Constructor
    public TreeBase() {
    }

    // SetRoot
    protected virtual void SetRoot(T? root, object? argument = null) {
        Assert.Argument.Message( $"Argument 'root' ({root}) must be valid" ).Valid( root != Root );
        if (root != null) {
            Assert.Operation.Message( $"Tree {this} must have no root" ).Valid( Root == null );
            Root = root;
            Root.Activate( this, argument );
        } else {
            Assert.Operation.Message( $"Tree {this} must have root" ).Valid( Root != null );
            Root.Deactivate( this, argument );
            Root = null;
        }
    }
    // SetRoot
    void ITree<T>.SetRoot(T? root, object? argument) => SetRoot( root, argument );

}
