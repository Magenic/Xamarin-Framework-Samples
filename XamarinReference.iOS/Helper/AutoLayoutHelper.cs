using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace XamarinReference.iOS.Helper
{
    public sealed class AutoLayoutHelper
    {
        private AutoLayoutHelper() { }
        public static NSLayoutConstraint SetHeight(UIView target, nfloat height)
        {
            if (target != null)     
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    target,
                    NSLayoutAttribute.Height,
                    NSLayoutRelation.Equal,
                    null,
                    NSLayoutAttribute.NoAttribute,
                    1,
                    height
                );

                target.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        public static NSLayoutConstraint SetWidth(UIView target, nfloat width)
        {
            if (target != null)         
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    target,
                    NSLayoutAttribute.Width,
                    NSLayoutRelation.Equal,
                    null,
                    NSLayoutAttribute.NoAttribute,
                    1,
                    width
                );

                target.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        /// <summary>        
        /// STATCODE_CA1709
        /// </summary>
        public static NSLayoutConstraint SetRelativeHeight(UIView ancestor, UIView outer, UIView inner, nfloat ratio)
        {
            if (ancestor != null)       
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.Height,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.Height,
                    ratio,
                    0
                );

                ancestor.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        public static NSLayoutConstraint SetRelativeWidth(UIView ancestor, UIView outer, UIView inner, nfloat ratio)
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                inner,
                NSLayoutAttribute.Width,
                NSLayoutRelation.Equal,
                outer,
                NSLayoutAttribute.Width,
                ratio,
                0
            );

            ancestor.AddConstraint(constraint);
            return constraint;
        }

        public static NSLayoutConstraint FollowControlVertically(UIView ancestor, UIView first, UIView next, nfloat margin)
        {
            if (ancestor != null)       
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    next,
                    NSLayoutAttribute.Top,
                    NSLayoutRelation.Equal,
                    first,
                    NSLayoutAttribute.Bottom,
                    1,
                    margin
                );

                ancestor.AddConstraint(constraint);
                return constraint;
            }

            return null;
        }

        public static NSLayoutConstraint FollowControlHorizontally(UIView ancestor, UIView first, UIView next, nfloat margin)
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                next,
                NSLayoutAttribute.Left,
                NSLayoutRelation.Equal,
                first,
                NSLayoutAttribute.Right,
                1,
                margin
            );

            ancestor.AddConstraint(constraint);
            return constraint;
        }

        public static NSLayoutConstraint CenterControlHorizontally(UIView outer, UIView inner)
        {
            if (outer != null)          
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.CenterX,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.CenterX,
                    1,
                    0
                );

                outer.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint CenterControlVertically(UIView outer, UIView inner)
        {
            if (outer != null)          
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    inner,
                    NSLayoutAttribute.CenterY,
                    NSLayoutRelation.Equal,
                    outer,
                    NSLayoutAttribute.CenterY,
                    1,
                    0
                );

                outer.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AlignBaselines
        (
            UIView ancestor,
            UIView fixedControl,
            UIView controlToAlign
        )
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToAlign,
                NSLayoutAttribute.Baseline,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.Baseline,
                1,
                0
            );

            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignTops
        (
            UIView ancestor,
            UIView fixedControl,
            UIView controlToAlign
        )
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToAlign,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.Top,
                1,
                0
            );

            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignCentersHorizontally(UIView ancestor, UIView fixedControl, UIView controlToCenter)
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToCenter,
                NSLayoutAttribute.CenterX,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.CenterX,
                1,
                0
            );

            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AlignCentersVertically(UIView ancestor, UIView fixedControl, UIView controlToCenter)
        {
            NSLayoutConstraint constraint = NSLayoutConstraint.Create
            (
                controlToCenter,
                NSLayoutAttribute.CenterY,
                NSLayoutRelation.Equal,
                fixedControl,
                NSLayoutAttribute.CenterY,
                1,
                0
            );

            ancestor.AddConstraint(constraint);

            return constraint;
        }

        public static NSLayoutConstraint AttachToParentLeft(UIView parent, UIView child, nfloat margin)
        {
            if (parent != null)         
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    child,
                    NSLayoutAttribute.Left,
                    NSLayoutRelation.Equal,
                    parent,
                    NSLayoutAttribute.Left,
                    1,
                    margin
                );

                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentRight(UIView parent, UIView child, nfloat margin)
        {
            if (parent != null)         
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    parent,
                    NSLayoutAttribute.Right,
                    NSLayoutRelation.Equal,
                    child,
                    NSLayoutAttribute.Right,
                    1,
                    margin
                );

                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentTop(UIView parent, UIView child, nfloat margin)
        {
            if (parent != null)         
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    child,
                    NSLayoutAttribute.Top,
                    NSLayoutRelation.Equal,
                    parent,
                    NSLayoutAttribute.Top,
                    1,
                    margin
                );

                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint AttachToParentBottom(UIView parent, UIView child, nfloat margin)
        {
            if (parent != null)         
            {
                NSLayoutConstraint constraint = NSLayoutConstraint.Create
                (
                    parent,
                    NSLayoutAttribute.Bottom,
                    NSLayoutRelation.Equal,
                    child,
                    NSLayoutAttribute.Bottom,
                    1,
                    margin
                );

                parent.AddConstraint(constraint);

                return constraint;
            }
            return null;
        }

        public static NSLayoutConstraint[] AttachToParentHorizontally(UIView parent, UIView child, nfloat margin)
        {
            NSLayoutConstraint[] result = new NSLayoutConstraint[2];

            result[0] = AttachToParentLeft(parent, child, margin);
            result[1] = AttachToParentRight(parent, child, margin);

            return result;
        }

        public static NSLayoutConstraint[] AttachToParentVertically(UIView parent, UIView child, nfloat margin)
        {
            NSLayoutConstraint[] result = new NSLayoutConstraint[2];

            result[0] = AttachToParentBottom(parent, child, margin);
            result[1] = AttachToParentTop(parent, child, margin);

            return result;
        }

        public static NSLayoutConstraint AttachToTopLevelGuide
        (
            UIView parent,
            IUILayoutSupport topGuide,
            UIView child,
            nfloat margin
        )
        {
            NSLayoutConstraint result = NSLayoutConstraint.Create
            (
                child,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                topGuide,
                NSLayoutAttribute.Bottom,
                1,
                margin
            );

            parent.AddConstraint(result);

            return result;
        }

        public static NSLayoutConstraint AttachToBottomLevelGuide
        (
            UIView parent,
            IUILayoutSupport bottomGuide,
            UIView child,
            nfloat margin
        )
        {
            NSLayoutConstraint result = NSLayoutConstraint.Create
            (
                bottomGuide,
                NSLayoutAttribute.Top,
                NSLayoutRelation.Equal,
                child,
                NSLayoutAttribute.Bottom,
                1,
                margin
            );

            parent.AddConstraint(result);

            return result;
        }
    }
}
